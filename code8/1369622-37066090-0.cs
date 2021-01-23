     static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\admin\Desktop\ConsoleApplication1\ConsoleApplication1\txtFile.txt");
            List<string> Codelst = new List<string>();
            foreach (var item in lines)
            {
                var a= Regex.Match(item, @"\d+").Value;
                Codelst .Add(a);
            }
            var r = Codelst;
        }
