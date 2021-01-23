           for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       MailMessage mesaj = new MailMessage();
                       if (dt.Rows[i]["durum"].ToString() == "Akademik")
                       {
    
                           mesaj.IsBodyHtml = true;
                           mesaj.Subject = "Doğum Günü";
                           mesaj.Body = "Sayın Akademik Personelimiz" + dt.Rows[i]["isim"].ToString() + " " + dt.Rows[i]["soyisim"].ToString() + " " + "Doğum Gününüz Kutlu Olsun";
    
    
                       }
                       else
                       {
    
    
                           mesaj.IsBodyHtml = true;
                           mesaj.Subject = "Doğum Günü";
                           mesaj.Body = "Sayın İdari Personelimiz" + " " + dt.Rows[i]["isim"].ToString() + "  " + dt.Rows[i]["soyisim"].ToString() + " " + "Doğum Gününüz Kutlu Olsun";
    
    
    
                       }
                       mesaj.To.Add(dt.Rows[i]["mail"].ToString());
                       client.Send(mesaj);
    
                   }
               }
