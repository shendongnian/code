    private void ProgressCallback(DownloadOperation obj)
    {
        MessageModel DLItem = listViewCollection.First(p => p.GUID == obj.Guid);
        if (obj.Progress.TotalBytesToReceive > 0)
        {
            double br = obj.Progress.BytesReceived;
            var result = br / obj.Progress.TotalBytesToReceive * 100;
            DLItem.Percent = result;
        }
    
        if (DLItem.Percent == 100)
        {
            DLItem.MessageType = _MessageType.Downloaded;
            listViewCollection.Remove(DLItem);
        }
    }
