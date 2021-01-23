    Declare a global List like this,  
     List<URLData> urls = new List<URLData>();
    public class URLData
    {
      public string URL { get; set; }
      public string timestamp { get; set; }
    }
    void Browser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
    {
         _deactivatedURL = e.Uri;
         _progressIndicator.IsVisible = false;
        textBox1.Text = Convert.ToString(e.Uri).Remove(0, 11);
        getHistory(textBox1.Text);
        listBox.ItemsSource = urls;  
    }
    private void getHistory(string url, string timestamp)
        {
          HistoryEntry urlObj = new HistoryEntry();
          urlObj.url = url;
          urlObj.timestamp = DateTime.Now.ToString("HH:mm yyyy-MM-dd");
          urls.Add(urlObj);
        }
