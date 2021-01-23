    public class TitleScraper {
    private string url;
    public TitleScraper(string url) { 
    this.url = url; 
    } 
    public string Title { get; set; } 
    public void Scrape() { 
    WebRequest request = WebRequest.Create(this.url); 
    WebResponse response = request.GetResponse(); 
    Stream data = response.GetResponseStream(); 
    StreamReader sr = new StreamReader(data); 
    string html = sr.ReadToEnd(); 
    string regex = @"(?<=<title.*>)([\s\S]*)(?=</title>)"; 
    System.Text.RegularExpressions.Regex ex = new System.Text.RegularExpressions.Regex(regex, System.Text.RegularExpressions.RegexOptions.IgnoreCase); 
    Title = ex.Match(html).Value.Trim(); 
    }
    } 
