    using(var client = new HttpClient())
    {
        var task = client.PostAsync(url1, ..., ...);
        
        if(!task.wait(5000))
        {
            //task not completed in specified interval (5 sec), take action accordingly.
        }
        else
        {
            // task completed within 5 second, take action accordingly, you can access the response using task.Result
        }
        // Continue with other urls as needed
    }
