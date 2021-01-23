            StreamReader sr = new StreamReader(@"C:\Test\kassenbestand.csv");
            sr.ReadLine();//skip the header
            while (sr.Peek() != -1)
            {
                string line1 = sr.ReadLine();
                string[] splitted = line1.Split(';');
                // splitted[0] Datum
                // splitted[1] Kassenbestand
                // ...
            }
            sr.Close();
