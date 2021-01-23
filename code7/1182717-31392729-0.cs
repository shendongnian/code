    private async Task SubmitJob()
        {
            
            JobModel job = new JobModel { ID = 42, name = "HelloJob", completion = 100.0f };
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsJsonAsync<JobModel>("http://localhost:53122/Jobs/Submit", job);
                if (response.IsSuccessStatusCode)
                    lblSuccess.Text = "Success!";
                else
                    lblSuccess.Text = "Failure!";
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
        }
        private async Task GetJobs()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://localhost:53122/Jobs/Info");
                if (response.IsSuccessStatusCode)
                {
                   List<JobModel> jobList = await response.Content.ReadAsAsync<List<JobModel>>();
                   txtConsole.Text = "";
                   foreach(var job in jobList)
                   {
                       string line = "ID: " + job.ID + " Name: " + job.name + " completion: " + job.completion + "\r\n";
                       txtConsole.Text += line;
                   }
                }
                else
                {
                    txtConsole.Text = "Failure!";
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
        }
