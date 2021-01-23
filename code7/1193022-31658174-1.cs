    foreach (var result in GameInfo)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<ul>");
        sb.AppendFormat("<p>My game information is as follows: {0}</p>", @result.Name);
        foreach (var result2 in SystemInfo)
        {
            sb.AppendFormat("<strong>System: {0}</strong>", @result2.System);
            foreach (var result3 in EditionInfo)
            {
                sb.AppendFormat("<strong>Price: {0}</strong>", @result3.Price);
                sb.AppendFormat("<strong>Edition: {0}</strong>", @result3.Edtion);
            }
        }
        sb.Append("</ul>");
        WebMail.Send("Test@test.com",
          "This is a test",
          body: sb.ToString(),
          isBodyHtml: true);  
    }
