    using (var progress = ObservableProgress<ProgressReport>.CreateForUi(value =>
        {
            ProgressFileReceive = (double)value.Progress / value.FileSize * 100;
        }))
    {
        await FileTransferAsync(progress);
    }
