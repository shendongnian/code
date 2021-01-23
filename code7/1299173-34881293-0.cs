    public Detail() : this(Guid.NewGuid())
    {
       
    }
    public Detail(Guid id) : this(new Header())
    {
        HeaderId = id;
    }
    public Detail(Header header) 
    {
        Header = header;
        DetailNumber = (Header.Details.Count) + 1;
    }
