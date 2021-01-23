    public async void Populate() {
      const string path = ...
      var files = new List<string>();
      await Task.Run(() => GetAllFiles(path, files));
      foreach (var file in files) {
        listView1.Items.Add(file);
      }
    }
