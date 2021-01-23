    try 
    {
        WebClient client = new WebClient();
        client.OpenReadAsync(new Uri(Url, UriKind.Absolute));
        client.OpenReadCompleted += (sender, e) =>
        {
            if (e.Error != null)
            {
                return;
            }
            else
            {
               try
               {
                  System.Xml.Linq.XDocument xmlDoc = XDocument.Load(e.Result);
                  IEnumerable<string> strTestURL = from node in xmlDoc.Descendants("url") select node.Value;
                  IEnumerable<string> strTestDescription = from node in xmlDoc.Descendants("copyright") select node.Value;
                  IEnumerable<string> strTestDate = from node in xmlDoc.Descendants("enddate") select node.Value;
                  string strURL = "http://www.bing.com" + strTestURL.First();
                  strURL = strURL.Replace("1366x768", "800x480");
                  Global.URL1 = strURL;
                  Global.URLs[i] = strURL;
                  Global.Descriptions[i] = strTestDescription.First();
                  Uri Uri = new Uri(Global.URLs[i], UriKind.Absolute);
                  Imageallgemein.Source = new BitmapImage(Uri);
                  Imageallgemein.Tap += new EventHandler<System.Windows.Input.GestureEventArgs>(onImageTap);
                  Imageallgemein.Hold += new EventHandler<System.Windows.Input.GestureEventArgs>(onImageTap);
                  Description.Text = Global.Descriptions[i];
                  string Year = strTestDate.First().Substring(0, 4);
                  string Month = strTestDate.First().Substring(4, 2);
                  string Day = strTestDate.First().Substring(6, 2);
                  Date.Text = Day + "." + Month + "." + Year;
               }
               catch (XmlException)
               {
                    MessageBox.Show(AppResources.Abort, AppResources.msgBoxUrlLoadError, MessageBoxButton.OK);
               }
            }
        };
    }
    catch (Exception)
    {
        MessageBox.Show(AppResources.Abort, AppResources.msgBoxUrlLoadError, MessageBoxButton.OK);
    }
