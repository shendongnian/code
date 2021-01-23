    class Program
    {
        static void Main(string[] args)
        {
            SimpleTest simpleTest = new SimpleTest();
            simpleTest.StatusChanged += SimpleTest_StatusChanged;
            simpleTest.Execute();
            Console.ReadLine();
        }
        private static void SimpleTest_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            Console.WriteLine($"{e.Percentage} - {e.Step}");
        }
    }
