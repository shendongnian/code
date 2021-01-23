    foreach (var result in GameInfo)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<ul>");
        sb.AppendFormat("<p>My game information is as follows: {0}</p>", @result.Name);
        foreach (var result2 in SystemInfo)
        {
            sb.AppendFormat("<p>System: {0}</p>", @result2.System);
            foreach (var result3 in EditionInfo)
            {
                sb.AppendFormat("<p>Price: {0}</p>", @result3.Price);
                sb.AppendFormat("<p>Edition: {0}</p>", @result3.Edtion);
            }
        }
        sb.Append("</ul>");
        WebMail.Send("Test@test.com",
          "This is a test",
          body: sb.ToString(),
          isBodyHtml: true);  
    }
