          StreamReader file = new StreamReader(@"test.txt");
          string line= file.ReadLine();
            while(line!=null)
            {
                if (line.Equals("5 8 1 7"))
                    MessageBox.Show(line);
                   line = file.ReadLine();
            }
       
        
