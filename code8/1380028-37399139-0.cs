    public JobResponse RunInformaticaJob(JobRequest jobRequest)
        {
            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("icSessionId", icSessionId);
                string message = JSONSerializer.Serialize(jobRequest);
                message = message.Insert(1, "\"@type\": \"job\",");
                byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
                var content = new ByteArrayContent(messageBytes);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = client.PostAsync(loggedUser.serverUrl + "/api/v2/job", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<JobResponse>().Result;
                }
                else
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
