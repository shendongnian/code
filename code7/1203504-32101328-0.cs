    namespace RabbitMQClient {   public class MessageQueueConsumer : IHealthVerifiable   {
        public class TimeoutException : Exception { }
    private class BufferQueue : SharedQueue<BasicDeliverEventArgs>
    {
      public int Count()
      {
        return this.m_queue.Count;
      }
    }
    
    private const int DEFAULT_ACK_COUNT = 1000;
    
    private String connString;
    private EventingBasicConsumer consumer;
    private IConnection conn;
    private IModel channel;
    private String queueName;
    private BufferQueue buffer;
    private Object locker = new Object();
    private ushort prefetchCount;
    private ushort ackCount;
    
    public MessageQueueConsumer(String queueName, String connString, ushort? ackCount = null)
    {
      this.queueName = queueName;
      this.connString = connString;
      if (ackCount != null)
        this.ackCount = ackCount.Value;
      else
        this.ackCount = DEFAULT_ACK_COUNT;
      this.prefetchCount = (ushort)(this.ackCount * 2);
    
      InitConsumer();
    }
    
    ~MessageQueueConsumer()
    {
      Close();
    }
    
    public void Close()
    {
      try
      {
        channel.Close(200, queueName + " Goodbye");
       // conn.Close();
      }
      catch { } //if already closed, do nothing
    }
    
    private void InitConsumer()
    {
      ConnectionFactory factory = new ConnectionFactory();
      factory.Uri = connString;
      conn = factory.CreateConnection();
      channel = conn.CreateModel();
      channel.BasicQos(0, prefetchCount, false);
      buffer = new BufferQueue();
    
      consumer = new EventingBasicConsumer(channel);
      channel.BasicConsume(queueName, false, consumer);
    
      // when message is recieved do following
      consumer.Received += (model, message) =>
      {
        while (true)
        {
          if (buffer.Count() > DEFAULT_ACK_COUNT)
            Thread.Sleep(3000);
          else
          {
            buffer.Enqueue(message);
    
            if (buffer.Count() == 0 || buffer.Count() == ackCount)
              channel.BasicAck(message.DeliveryTag, true);
          }
        }
      };
    }
    
    /// <summary>
    /// Get the next event from the queue
    /// </summary>
    /// <returns>Event</returns>
    public byte[] Dequeue(int? timeout = null)
    {
      lock (locker)
      {
        try
        {
          return AttemptDequeue(timeout);
        }
        catch (EndOfStreamException)
        {
          // Network interruption while reading the input stream
          InitConsumer();
          return AttemptDequeue(timeout);
        }
        catch (OperationInterruptedException)
        {
          // The consumer was removed, either through channel or connection closure, or through the
          // action of IModel.BasicCancel().
          // Attempt to reopen and try again
          InitConsumer();
          return AttemptDequeue(timeout);
        }
        catch (ConnectFailureException)
        {
          //Problems connecting to the queue, wait 10sec, then try again. 
          Thread.Sleep(10000);
          InitConsumer();
          return AttemptDequeue(timeout);
        }
      }
    }
    
    private byte[] AttemptDequeue(int? tomeout)
    {
      BasicDeliverEventArgs message;
    
      while (true)
      {
        //while buffer has no events
        if (buffer.Count() == 0)
        {
          Thread.Sleep(3000);
        }
        else
        {
          message = buffer.Dequeue();
          break;
        }
    
      }
    
      try
      {
        return message.Body;
      }
      catch (Exception e)
      {
        throw new SerializationException("Error deserializing queued message:", e);
      }
    }
    
    /// <summary>
    /// Attempt to connect to queue to see if it is available
    /// </summary>
    /// <returns>true if queue is available</returns>
    public bool IsHealthy()
    {
      try
      {
        if (channel.IsOpen)
          return true;
        else
        {
          InitConsumer();
          return true;
        }
      }
      catch
      {
        return false;
      }
    }   } }
