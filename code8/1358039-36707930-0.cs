    public class MyClass
    {
        public void CreateFile()
        {
            string path = @"c:\temp\MyTest.txt";
            if (!File.Exists(path)) 
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path)) 
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }	
            }
        }
    }
