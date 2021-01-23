        static void Main(string[] args)
        {
            List<int> input = Enumerable.Range(0, 20).ToList();
            BufferBlock<int> buffer1 = new BufferBlock<int>();
            BatchBlock<int> buffer2 = new BatchBlock<int>(5);
            ActionBlock<int> action1;
            ActionBlock<int[]> action2;
            action1 = new ActionBlock<int>(t => { Consumer(t, buffer2); },
                new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 1 });
            buffer1.LinkTo(action1, new DataflowLinkOptions { PropagateCompletion = true });
            action2 = new ActionBlock<int[]>(t => Finalizer(t),
                new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 1 });
            buffer2.LinkTo(action2, new DataflowLinkOptions { PropagateCompletion = true });
            Task produceTask = Task.Factory.StartNew(() => Producer(input, buffer1));
            Task.WaitAll(produceTask);
            action1.Completion.Wait();//Will add all the items to buffer2
            buffer2.Complete();//will not get any new items
            action2.Completion.Wait();//Process the batch of 5 and then complete
            Console.WriteLine("Process complete");
            Console.ReadLine();
        }
        private static void Finalizer(int[] t)
        {
            Console.WriteLine("Received a batch of items {0}", t.Count());
            foreach (int i in t)
            {
                // Do some work
                Console.WriteLine("Finalizer saw item " + i);
                System.Threading.Thread.Sleep(1000);
            }
        }
        private static void Consumer(int t, BatchBlock<int> buffer2)
        {
            Console.WriteLine("Consumer saw item " + t);
            buffer2.Post(t);
        }
        public static void Producer(List<int> input, BufferBlock<int> buffer1)
        {
            foreach (int i in input)
            {
                buffer1.Post(i);
            }
            //Once marked complete your entire data flow will signal a stop for
            // all new items
            buffer1.Complete();
        }
