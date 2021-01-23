            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authUser);
                Task<HttpResponseMessage> task = client.GetAsync(uri);
                **HttpResponseMessage msg = task.Result;**
                task.Wait();
                return task.Result;
            }
