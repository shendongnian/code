    public **async** Task<bool> SignersAdded(string packageId)
    {
       var timeout = TimeSpan.FromSeconds(5);
       var task = Task.Run(() =>
       {
          var package = _eslClient.GetPackage(new PackageId(packageId));
          return package != null
              && package.Documents.Values
                        .Any(x => x.Signatures.Any());
        });
        // if desired you can do other things here
        // once you need the answer start waiting for it and return the result:
        return await Task;
    }
