        class ProducerConsumer
        {
            private BlockingCollection<string> collection;
            ICollection<Thread> consumers;
            string fileName;
            public ProducerConsumer(string fileName)
            {
                this.fileName =  fileName;
                collection = new BlockingCollection<string>();
                consumers = new List<Thread>();
                var consumer = new Thread(() => Consumer());
                consumers.Add(consumer);
                consumer.Start();
            }
            private async Task StartWork()
            {
                using (TextReader reader = File.OpenText(fileName))
                {
                    var line = await reader.ReadLineAsync();  
                    collection.Add(line);
                }
            }
            private void Consumer()
            {
                while (true /* insert your abort condition here*/)
                {
                    try
                    {
                        var line = collection.Take();
                        // Do whatever you need with this line. If proccsing this line takes longer then 
                        // fetching the next line (that is - the queue lenght increasing too fast) - you
                        // can always launch an additional consumer thread.
                    }
                    catch (InvalidOperationException) { }
                }
            }
        }
