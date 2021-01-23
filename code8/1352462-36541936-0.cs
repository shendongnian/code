      //byte[] image = (byte[])dgv.Rows[i].Cells[7].Value;
      
      Image image = (Image)dgv.Rows[i].Cells[7].Value;
      using (MemoryStream m = new MemoryStream())
      {
            image.Save(m, image.RawFormat);
            byte[] imageBytes = m.ToArray();
            // Convert byte[] to Base64 String
            string base64String = Convert.ToBase64String(imageBytes);
      }
