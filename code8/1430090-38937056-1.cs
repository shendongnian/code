    using System;
    using System.IO;
    using System.Text;
    class Test
    {
        public static void Main()
        {
            string File1 = @"c:\temp\MyTest1.txt";
            string File2 = @"c:\temp\MyTest2.txt";
          
            if (File.Exists(File1))
            {
                string appendText = File.ReadAllText(File1);
                if (File.Exists(File2))
                {
                    appendText += File.ReadAllText(File2);
                }
            }
        }
    }
