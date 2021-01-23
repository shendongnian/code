    if (File.Exists(path))
    {
        using (TextReader tr = new StreamReader(path))
        { 
            Response.Write("<table>");
            while (tr.Peek() != -1)
            {
                Response.Write("<tr><td>");
                Response.Write(String.Join("</td><td>", tr.ReadLine().Split('/t')));
                Response.Write("</td></tr>");
            }
            Response.Write("</table>");
        }
    }
