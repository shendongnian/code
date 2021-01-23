        using System;
        using System.Data;
        using System.IO;
        using System.Collections.Generic;
        
    class test
    {
        public Dictionary<int, String> readAndSortFile()
        {
            StreamReader sr = new StreamReader("file.txt");
            Dictionary<int, String> dic = new Dictionary<int, string>();
    
            int loop = 0;
            while (!sr.EndOfStream)
            {
                dic.Add(loop, sr.ReadLine());
                loop++;
            }
            sr.Close();
    
            return dic;
        }
    }
