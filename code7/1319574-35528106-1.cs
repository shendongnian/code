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
//Note: If you have you are trying to read from a document file instead of the URL, You can use the following instead
    public void Scrape() { 
    string filePath = @"c:\user\filename.doc"; //location to your file
    StreamReader sr = new StreamReader(filePath);
    string text = sr.ReadToEnd();
    sr.Close();
    string regex = @"(?<=<title.*>)([\s\S]*)(?=</title>)"; 
    System.Text.RegularExpressions.Regex ex = new System.Text.RegularExpressions.Regex(regex, System.Text.RegularExpressions.RegexOptions.IgnoreCase); 
    Title = ex.Match(text).Value.Trim();
}
