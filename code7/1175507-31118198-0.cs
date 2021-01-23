               for (int i = 0; i < dt.Rows.Count; i++)
               {
                  MailMessage mesaj = new MailMessage();
                  < rest of your code here>
                  mesaj.To.Add(dt.Rows[i]["mail"].ToString());
                  client.Send(mesaj);
               }
