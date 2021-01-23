    private void test()
    {
        var response = new ResponseResult();
        var javaScriptSerializer = new JavaScriptSerializer();
        response.Status = -1;
        response.ErrorMessage = "";
        response.Action = "UserProjects";
        response.Data = "The Username or password you entered is not valid";
        string result = javaScriptSerializer.Serialize(response);
        
        Response.Clear();
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(result);  //write json string to output   
    }
