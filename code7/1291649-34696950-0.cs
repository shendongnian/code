    try {
        string credentials = ConfigurationManager.AppSettings["jenkinsUser"] + ":" + ConfigurationManager.AppSettings["jenkinsKey"];
        string authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.Authorization] = "Basic " + authorization;
            string HtmlResult = wc.UploadString(String.Format(ConfigurationManager.AppSettings["jenkinsDeleteJobUrl"], jobName), "POST", "");
        }
    }
    catch (WebException e)
    {
        // ignore the 403 error for now
        HttpWebResponse errorResponse = e.Response as HttpWebResponse;
        if(errorResponse.StatusCode != HttpStatusCode.Forbidden)
        {
            throw e;
        }
    }
    
    // if the job no longer exists, it is proof that the request went through
    if(!JenkinsHelper.GetJenkinsJobs().Contains(jobName))
    {
        Console.WriteLine("Job successfully deleted.");
        return true;
    }
    else
    {
        Console.WriteLine("Could not delete job.");
        return false;
    }
