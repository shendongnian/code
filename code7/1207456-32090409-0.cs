    public void UploadData(List<Data> allDataToUpload)
    {
        Parallel.ForEach(allDataToUpload, data =>
        {
            _yourService.Upload(data);
        });
    }
    
