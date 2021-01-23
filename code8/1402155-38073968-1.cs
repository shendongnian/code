    StringBuilder sb = new StringBuilder();
        using (StreamReader sr = new StreamReader(@"C:\Users\p2\Desktop\variablen.txt"))
       {
                       string line;
                       
                       // Read and display lines from the file until 
                       // the end of the file is reached. 
                       while ((line = sr.ReadLine()) != null)
                       {
                          sb.Append((line);
                       }
        }
        monate2.Text = sb.Tostring();
