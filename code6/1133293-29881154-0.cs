      // in .NET, you need to add a reference
      // to the WUAPI COM component located in \windows\system32\wuapi.dll
      // to be able to access the WUAPI object model
      UpdateSearcher searcher = new UpdateSearcher();
      searcher.Online = false; // you can remove this line if you allow the API to get online to search
      var res = searcher.Search("IsInstalled=0"); // search not installed update
      foreach (IUpdate update in res.Updates)
      {
          Console.WriteLine("update:" + update.Title);
    
          // get history information
          // this can return nothing for example it it was hidden by end user
          // note we use update's identity and rev number here for matching a specific update
          var histories = searcher.QueryHistory(0, searcher.GetTotalHistoryCount()).OfType<IUpdateHistoryEntry>().Where(
              h => h.UpdateIdentity.UpdateID == update.Identity.UpdateID && h.UpdateIdentity.RevisionNumber == update.Identity.RevisionNumber);
          foreach (var history in histories)
          {
              Console.WriteLine(" code:" + history.ResultCode);
              Console.WriteLine(" hr:0x" + history.HResult.ToString("X8"));
          }
      }
