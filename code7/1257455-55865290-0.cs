    private LinkGroupCollection _menuLinkGroups = new LinkGroupCollection();
            
    public LinkGroupCollection MenuLinkGroups
    {
        get => _menuLinkGroups;
        set => SetProperty(ref _menuLinkGroups, value);
    }
    
    private LinkCollection _titleLinks = new LinkCollection();
            
    public LinkCollection TitleLinks
    {
        get => _titleLinks;
        set => SetProperty(ref _titleLinks, value);
    }
