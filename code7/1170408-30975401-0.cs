    foreach (string x in urllist.Lines)
       {
    try
    {
           string EndOfURL = x.Substring(x.Length - 4);
           if (Url_checker(x) && (EndOfURL == ".jpg" || EndOfURL == ".gif" || EndOfURL == ".jpeg" || EndOfURL == ".png"))
           {
              byte[] data;
             //using (WebClient client = new WebClient())
              //{
              WebClient client = new WebClient();
                  data = client.DownloadData(x);
             // }
              File.WriteAllBytes(saveToThisFolder + @"\" + (i++ + EndOfURL), data);
              counter++;
              workingURL.Text += x; //+ System.Environment.NewLine
           }
          else
          {
              errorURL.Text += (x + System.Environment.NewLine);
          }
       }
    }
    catch(Exception ex)
    {//todo : add some logging here}
