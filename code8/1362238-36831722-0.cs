    private async Task _InetGetHTMLSearchAsync(string sTitle)
    {
      Runs++;
      string sResearchURL = "http://www.audiodump.biz/music.html?" + AudioDumpQuery + sTitle.Replace(" ", "+");
      try
      {
        using (var client = new WebClient())
        {
          client.Headers.Add("Referer", @"http://www.audiodump.com/");
          client.Headers.Add("user-agent", "Mozilla / 5.0(Macintosh; Intel Mac OS X 10_9_3) AppleWebKit / 537.75.14(KHTML, like Gecko) Version / 7.0.3 Safari / 7046A194A");
          string[] sStringArray;
          string aRet = await client.DownloadStringTaskAsync(new Uri(sResearchURL));
          string[] aTable = _StringBetween(aRet, "<BR><table", "table><BR>", RegexOptions.Singleline);
          if (aTable != null)
          {
            string[] aInfos = _StringBetween(aTable[0], ". <a href=\"", "<a href=\"");
            if (aInfos != null)
            {
              for (int i = 0; i < 1; i++)
              {
                sStringArray = aInfos[i].Split('*');
                sStringArray[0] = sStringArray[0].Replace("&#39;", "'");
                aLinks.Add(sStringArray[0]);
              }
              await DownloadFile(aLinks[FilesDownloaded]); // Should really be called "DownloadFileAsync"
            }
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Debug message: " + ex.Message + "InnerEx: " + ex.StackTrace);
        Console.WriteLine("Runs: " + Runs);
        return;
      }
    }
