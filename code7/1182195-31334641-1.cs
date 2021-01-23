    private void UpdateToolbar()
    {
        // Check which items should be visible and add it to the list
        var itemlist = new List<UIBarButtonItem>();
    
        var img = IsCorrect ? "Icon_Correct" : "Icon_incorrect";
        var mybtn= CreateToolbarItem(img);
    
        itemlist.Add(mybtn);
    
        // Set toolbaritems
        SetToolbarItems(itemlist.ToArray(), false);
    }
    
    public static UIBarButtonItem CreateToolbarItem(String name)
    {
        var btn = new UIButton(UIButtonType.Custom);
        btn.SetImage(UIImage.FromBundle(name), UIControlState.Normal);
        btn.Frame = new CGRect(0, 0, 32, 32);
        return new UIBarButtonItem(btn);
    }
