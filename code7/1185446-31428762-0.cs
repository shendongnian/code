	class ProducerConsumerExample
	{
		BlockingCollection<float> samples32Collection;
		Thread consumer;
		public ProducerConsumerExample()
		{
			samples32Collection = new BlockingCollection<float>();
			consumer = new Thread(() => LaunchConsumer());
            consumer.Start();   //you don't have to luanch the consumer here...
		}
		void Terminate()    //Call this to terminate the consumer
		{
			consumer.Abort();
		}
		void myWaveIn_DataAvailable(object sender, WaveInEventArgs e)
		{
			for (int index = 0; index < e.BytesRecorded; index += 2)//Here I convert in a loop the stream into floating number samples
			{
				short sample = (short)((e.Buffer[index + 1] << 8) |
										e.Buffer[index + 0]);
				samples32Collection.Add(sample / 32768f);
			}
		}
		void LaunchConsumer()
		{
			while (true /* insert your abort condition here*/)
			{
				try
				{
					var sample = samples32Collection.Take();   //this thread will wait here until the producer add new item(s) to the collection
                    Process(sample);    //in the meanwhile, more samples could be added to the collection 
                                        //but they will not be processed until this thread is done with Process(sample)
				}
				catch (InvalidOperationException) { }
			}
		}
	}
