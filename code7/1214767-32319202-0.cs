    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyDOM.Root document = MyDOM.Root.CreateExampleDocument();
                MySoapResponse responseGenerator = new MySoapResponse(document);
                System.IO.File.WriteAllText(@"E:\temp\blabla.txt", responseGenerator.TransformText());
                System.Console.WriteLine("Done transforming!");
            }
        }
    }
