    void SaveStringToFile(string str)
    {
       using (System.IO.StreamWriter file = 
               new   System.IO.StreamWriter(@"C:\test.txt"))
       {
           file.WriteLine(str);
       }
    }
 
