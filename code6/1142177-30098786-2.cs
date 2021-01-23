    NameValueCollection postData = Request.Form;
    string name, username;
    if (!string.IsNullOrEmpty(postData["name"]))
    {
      name = postData["name"];
    }
    if (!string.IsNullOrEmpty(postData["username"]))
    {
      username = postData["username"];
    }
