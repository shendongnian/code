    namespace ConsoleApplication4
    {
        public class Processor
        {
            public void generateNumbers()
            {
                Random rand = new Random();
                AddModel addModel = findSum(rand);
                Console.WriteLine("Number1: " + addModel.Left);
                Console.WriteLine("Number2: " + addModel.Right);
                Console.WriteLine("Sum: " + addModel.Sum);
            }
    
            private AddModel findSum(Random rand)
            {
                AddModel addModel = new AddModel();
                addModel.Left = rand.Next(1, 11);
                addModel.Right = rand.Next(1, 11);
                addModel.Sum = addModel.Left + addModel.Right;
                return addModel;
            }
        }
    }
