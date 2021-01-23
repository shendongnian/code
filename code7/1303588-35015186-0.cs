       using (Entities db = new Entities()) //Entity object
        {
            try
            {
                db.Komitents.RemoveRange(db.Komitents);
        		// Jonathan: Let make 2 SaveChanges call for now to understand what's happening
        		db.SaveChanges();
        		
        		// Jonathan: Create a list to use AddRange to improve performance
        		List<Komitent> list = new List<Komitent>();
        		
                for (int i = 0; i < 400; i++)
                {
                    DataRow row = dt.Rows[i];
                    if (row["naziv"].ToString() != "")// skips header row
                    {
                        Komitent k = new Komitent();
                        k.Sif_komit = Convert.ToInt32(row["sif_komin"].ToString());
                        k.Naziv = row["naziv"].ToString();
                        k.Oib = row["oib"].ToString();
                        k.Mjesto = row["mjesto"].ToString();
                        k.Adresa = row["adresa"].ToString();
                        k.Telefon = row["telefon"].ToString();
                        k.Telefax = row["telefax"].ToString();
                        k.Mobitel = row["mobitel"].ToString();
                        k.Kontakt = row["kontakt"].ToString();
        
                        list.Add(k);
                        bw.ReportProgress((int)(100.0 / dt.Rows.Count) * i, null);
        
                        if (pb.InvokeRequired)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                pb.Value = (int)((100.0 / dt.Rows.Count) * i);
                            });
        
                        }
                    }
                }
        		
        		// Jonathan: Put a break point here to make sure the list contains 1200 rows
        		db.AddRange(list);
        
                db.SaveChanges();
        	}
        	catch
        	{
        		// Jonathan: Let throw the error for now until it fixed
        		throw;
        	}
        }
