    public string AttachUrl
    {
        get
        {                                                   // here
            return string.Format("{0}/image/Message/Attachment/{1}", url, Id);
        }
    }
