         //Class for book details
    
        public class BookDetails
        {
          private string Error {get; set;}
          private string Time {get; set;}
          private string ID {get; set;}
          private string Title {get; set;}
          private string SubTitle {get; set;}
          private string Description {get; set;}
          private string Author {get; set;}
          private string ISBN {get; set;}
          private string Year {get; set;}
          private string Page {get; set;}
          private string Publisher {get; set;}
          private string Image {get; set;}
          private string Download {get; set;}
        }
    
        private async void download_btn_Click(object sender, RoutedEventArgs e)
        {
            string downloadbookurl=string.empty;
               
           //Download the book detail using API http://it-ebooks-api.info/v1/book/2279690981
             string result=GetResult("http://it-ebooks-api.info/v1/book{book_isbn}")
           //Deserialise the json data
             BookDetails bookDetails= JsonConvert.DeserializeObject<BookDetails >(result);
             if(bookDetails!=null)
                    downloadbookurl=bookDetails.Download ;
        
             }
              //Launch the webview
                     await Launcher.LaunchUriAsync(new Uri(downloadbookurl));
        }
    
        private async string GetResult(string url)
        {
             string response=string.empty;
             using (HttpClient client = new HttpClient())
             {
               client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
               HttpResponseMessage response = await client.GetAsync(String.Format(uri, tb1.Text));
               if (response.IsSuccessStatusCode)
               {
                 var data = response.Content.ReadAsStringAsync();
                 response=data.Result.ToString();
                }
             } 
        }
