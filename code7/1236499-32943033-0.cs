      public string GetImage(object img)
        {
         string base64String ="";
        if (dt.Rows[0]["Pic"] != DBNull.Value)
                        {
                            byte[] bytes = (byte[])dt.Rows[0]["Pic"];
                            base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                           
                         }
           return "data:image/png;base64," + base64String ;
        }
