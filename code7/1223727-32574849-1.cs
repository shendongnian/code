    String[] arrayOld = File.ReadAllLines(@"C:\test.txt");
    String[] arrayNew = new string[arrayOld.Length];
    
     if (arrayOld[0].Contains("Licfile=")) // If statements could be more
      {
        Array.Copy(arrayOld,0,arrayNew,0,2); // How many line will add
      }
    
     for (int i = 0; i < 2; i++)
       {
        File.AppendAllText(@"D:\test2.txt", arrayNew[i] + Environment.NewLine); // It'll add all lines
       }
