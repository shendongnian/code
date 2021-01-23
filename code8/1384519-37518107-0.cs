    public static void WriteToFile(string s)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "a.txt";
            var fs = new System.IO.FileStream(path, System.IO.FileMode.Append, System.IO.FileAccess.Write);
            var sw = new System.IO.StreamWriter(fs);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            fs.Close();
            Console.WriteLine(path);
            Console.ReadKey();
        }
