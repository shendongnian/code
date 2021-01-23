      for (int i = 1; i < 17; i++)
        {                       
          var dir = System.IO.Directory.CreateDirectory
          (String.Format(@"C:\Users\xxx\Desktop\xx\Test{0:d2}", i));
          System.IO.File.Create(dir.FullName+ @"\MyFile.txt");
        }
