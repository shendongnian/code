    Task<string> t = new Task<string>(cryptor.Encrypt);
    T.Start();
    Task continuationTask = t.ContinueWith((encryptTask) => {
        txtBox.Text = encryptTask.Result;
        ...
    })
