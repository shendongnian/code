    // Note: I can't remember is Section is required or not
    private const string Header = @"<Section xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""><Paragraph>";
    private const string DefaultContent = "This is an example of button content. This is a very long content";
    private const string Footer = "</Paragraph></Section>";
    private string _search;
    public string Search
    { 
        get { return _search; }
        set {
             if (Set(ref _search, value))  // using MVVMLight
             {
                 // search value was updated
                 this.ButtonContent = Header + DefaultContent.Replace(value, "<Italic>" + value + "</Italic>") + Footer;
             }
        }
    }
