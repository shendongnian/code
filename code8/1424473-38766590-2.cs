    message = new HttpClient().GetMessage(host, path, q).Result;
    tracks = message.GetObjectFromMessage<List<InvoiceAndItemsDTO>>().Result;
    if (tracks != null)
    {
        invoice = tracks.First();
    }
