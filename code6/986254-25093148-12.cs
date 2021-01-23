    StringBuilder sb = new StringBuilder();
    sb.AppendLine(Session["names"].ToString());
    foreach(DataRow r in newTable.Rows)
    {
        sb.AppendLine("\"" + string.Join("\",", r.ItemArray) + "\"");
    }
    string name = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + "__" + ".csv";
    System.IO.File.WriteAllText(Server.MapPath("~/export/" + name), sb.ToString());
    Response.Redirect("~/export/" + name);
