    HtmlTextWriter wr = new HtmlTextWriter(Response.Output);
    
    using (var rdr = cmd.ExecuteReader())
    {
        int index = 0;
    
        wr.WriteBeginTag("table");
        wr.WriteLine("<tr><td>Column 1</td><td>Column 2</td></tr>");
    
        while (rdr.Read())
        {
            wr.WriteBeginTag("tr");
            
            wr.WriteBeginTag("td");
            wr.Write(rdr["Column1"]);
            wr.WriteEndTag("td");
            
            wr.WriteBeginTag("td");
            wr.Write(rdr["Column2"]);
            wr.WriteEndTag("td");
            
            wr.WriteEndTag("tr");
            
            if (index++ % 1000 == 0) Response.Flush();
        }
        
        wr.WriteEndTag("table");
    }
