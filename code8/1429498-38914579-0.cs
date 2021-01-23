            int i = 0; 
            while(i < dt.Rows.Count)
            {
                string duration = dt.Rows[i][1].ToString();
                if (duration == "")
                {
                    dt.Rows[i].Delete();
                }
                else
                {i++;}
                Console.WriteLine(i.ToString() + dt.Rows[i][1].ToString());
            }
