    bool includeMessage = users.Any(u => u.Message == "Success");
    object content = null;
    if(includeMessage) {
        content = new { message = "Success", supervisorlist = users };
    } else {
        content = new { supervisorlist = users };
    }
    
    resp = new HttpResponseMessage { 
                Content = new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json") 
            };
