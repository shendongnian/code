            // code snipped...
            if (Session["kullanici"] != null)
            {
                Response.Write("Hoşgeldiniz..." + Session["kullanici"]);
                Response.Redirect("KayitAyrinti.aspx");
            }
            else
            {
               // Response.Write("Giriş Yapınız.");
            }
            if (!IsPostback)  // <-- Add this check
            {
                string connectionString = "xxx;Database=xxx;Uid=xxxx;Pwd=xxx;";
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    string[] keys = Request.QueryString.GetValues("id");
                    /// rest of code snipped 
  
