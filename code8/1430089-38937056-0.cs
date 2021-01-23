      class Test
         {
         public static void Main()
            {
              string File1 = @"c:\temp\MyTest1.txt";
              string File2 = @"c:\temp\MyTest2.txt";
          
             if (File1.Exists(path))
               {
               string appendText = File.ReadAllText(File1);
    
               if (File2.Exists(path))
                  {
                   appendText += File.ReadAllText(File2);
                  }
                }
    
             }
          }
