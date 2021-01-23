      //we first need the file id
      string id = string.Empty;
      //we need to get all of the filenames stored in the root of the skydrive account
      LiveOperationResult result = await this.client.GetAsync("me/skydrive/files");
      //lets make a list of all these filenames
      List<object> items = result.Result["data"] as List<object>;
      //for every filename, check if it is what we want, in this case "sample.txt"
      //if it is what we want, get the id and save it to out already defined id value
      foreach (object item in items)
      {
          IDictionary<string, object> file = item as IDictionary<string, object>;
          if (file["name"].ToString() == "sample.txt")
          {
                id = file["id"].ToString();
          }
      }
      //to download the file we need to use the id + "/content"
      LiveDownloadOperationResult result2 = await client.DownloadAsync(string.Format("{0}/content", id));
      //once the file had downloaded, lets copy it to IsolatedStorage
     Stream stream = result2.Stream;
     using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
     {
         using (IsolatedStorageFileStream fileToSave = storage.OpenFile("sample.txt", FileMode.Create, FileAccess.ReadWrite))
         {
                stream.CopyTo(fileToSave);
                stream.Flush();
                stream.Close();
         }
    }
