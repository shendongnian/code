        static void Main(string[] args)
        {
            RunAsync().Wait();
        }
        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3963/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string filepath = "C:/Users/Popper/Desktop/Stackoverflow/MatchPositions.PNG";
                string filename = "MatchPositions.PNG";
                MultipartFormDataContent content = new MultipartFormDataContent();
                ByteArrayContent fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(filepath));
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = filename };
                content.Add(fileContent);
                HttpResponseMessage response = await client.PostAsync("api/Upload?participantsId=2&taskId=77&EnteredAnswerOptionId=235", content);
                string returnString = await response.Content.ReadAsAsync<string>();
            }
        }
