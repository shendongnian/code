    private void WebBrowser_Navigated(object sender, NavigationEventArgs e)
            {
                 string url  = Convert.ToString(e.Uri).Remove(0, 11);
                 HistoryEntry urlObj = new HistoryEntry();
                 urlObj.URL = url;
                 urlObj.timestamp = DateTime.Now.ToString("HH:mm yyyy-MM-dd");
                 urls.Add(urlObj);
                 listBox.ItemsSource  = null;
                 listBox.ItemsSource = urls;
            }
