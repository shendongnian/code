    class BlockingQueue<T>
    {
    	private Queue<T> myQueue = new Queue<T>();
    	
    	public void Enqueue(T t)
    	{
    		lock(myQueue)
    		{
    			myQueue.Enqueue(t);
    			Monitor.Pulse(myQueue);
    		}
    	}
    	public T Dequeue()
    	{		
    		lock(myQueue)
    		{
    			Monitor.Wait(myQueue);
    			return myQueue.Dequeue();
    		}
    	}
    }
