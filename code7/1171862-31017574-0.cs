    using System;
    using System.IO;
    
    class Test
    {
        public void Read()
        {
            try
            {
                using (StreamReader sr = new StreamReader("yourFile"))
                {
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
