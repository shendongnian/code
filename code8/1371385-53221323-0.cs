    ApplicationData.Current.LocalFolder.GetFileAsync(path).AsTask().ContinueWith(item => { 
        if (item.IsFaulted)
            return; // file not found
        else { /* process file here */ }
    });
