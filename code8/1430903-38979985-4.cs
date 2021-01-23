     Dictionary<string, string> postData = new Dictionary<string, string>();
     foreach (string key in Request.Form.AllKeys)
     {
            postData.Add(key, Request.Form[key]);
     }
     postData.Add("new-key", "new-value"); //add new values here.
     ViewBag.formPostData = postData;
