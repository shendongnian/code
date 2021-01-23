    cmd2.CommandText = "select * from Blogs order by id desc"; 
    SqlDataReader reader = cmd2.ExecuteReader(); 
    List<Blogs> blogslist = new List<Blogs>(); 
    while (reader.Read()) 
    { 
       var blog = new Blogs();
       blog.Id = Convert.ToInt16(reader["id"]); 
       blog.email = reader["email"].ToString(); 
       blog.description = reader["description"].ToString(); 
       blog.date =Convert.ToDateTime(reader["date"]); 
       blogslist.Add(blog); 
    }
