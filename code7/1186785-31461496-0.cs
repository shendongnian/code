    public Task<bool> SignersAdded(string packageId)
    {
        var timeout = 5000;
        var task = Task.Run(() =>
        {
            var package = _eslClient.GetPackage(new PackageId(packageId));
            return package != null && package.Documents.Values.Any(x => x.Signatures.Any());
        });
        if(!task.Wait(1000 /*timeout*/))
        {
            // timeout
            return false;
        }
        return task.Result;
    }
