        foreach (string s in lines)
        {
            string[] lines2 = s.Split('\t');
            if (lines2.Length == 4)
            {
              var1 = lines2[0];
              var2 = lines2[1];
              var3 = lines2[2];
              var4 = lines2[3];
              Console.WriteLine(var4);
            }
            else
            { 
                 // report error?
            }
          }
        }
