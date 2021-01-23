    static void Main(string[] args)
    {
        var LoanDateRange = new DateModel();
            LoanDateRange.LoadStart = startDate.ToString();
            LoanDateRange.LoadEnd = endDate.ToString();
        using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://mybank1.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(LoanDateRange), Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage response = await client.PostAsync("api/loans/range/enroll", content);
                    if (response.IsSuccessStatusCode)
                    {
                        //MessageBox.Show("Upload Successful", "Success", MessageBoxButtons.OK);
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        Console.ReadLine();
    }
