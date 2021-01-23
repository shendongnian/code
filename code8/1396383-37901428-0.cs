    XDocument xDoc = new XDocument(new XElement("Root"));
    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["###"].ConnectionString))
    {
        con.Open();
    
        using (SqlCommand command = new SqlCommand("####", con))
        {
            XElement article;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                xDoc.Add(article = new XElement("article"));
                article.Add(new XElement("status", "Approved"));
                string title;
                article.Add(new XElement("title", title = reader.GetString(0)));
                article.Add( new XElement("subtitle", title));
                article.Add(new XElement("synopsis", reader.GetString(4) + "..."));
    
                string pub = reader["publication_id"].ToString();
                string iss = reader["issue_id"].ToString();
                string sid = reader["STORYID"].ToString(); 
    
                string c = url(title, pub, iss, sid);
                article.Add(new XElement("url", c));
    
                article.Add(new XElement("display_date", DateTime.Today));
            }
        }
    }
