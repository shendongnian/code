    string response = string.Format("[ \"tableColumn1\": \"{0}\",\"tableColumn2\":\"{2}\"]", value1, value2).Replace('[', '{').Replace(']', '}');
    Response.Clear();
    Response.ContentType = "application/json; charset=utf-8";
    Response.Write(response );
    Response.End();
