    public string OmniPageName
    {
        get
        {
            return (ViewBag._OmniPageName ?? "").ToString();
        }
        set
        {
            ViewBag._OmniPageName = value;
        }
    }
