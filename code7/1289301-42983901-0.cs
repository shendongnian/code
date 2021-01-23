     string result = "";
                string methodName = "GetCourse";                  
                string apiName = "core_course_get_courses";           
                string apiCall = moodleUrl + "?wstoken=" + token + "&wsfunction=" + apiName + "&moodlewsrestformat=json";
    
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.BaseAddress = apiCall;
                        client.Headers[HttpRequestHeader.Accept] = "application/json";
                        result = client.DownloadString(apiCall);
