    public void Process(GetContentEditorWarningsArgs args)
    {
        string displayName;
        this._item = args.Item;
        if (!this._isValidForProcessing())
            return;
        User user = null;
        List<string> strs = this._getRolesForUser(this._item.Statistics.CreatedBy, out user);
        List<string> strs1 = this._getRolesForUser(Context.User);
        if (strs.Any<string>() && strs1.Any<string>() && strs1.Any<string>((string r) => strs.Contains(r)))
            return;
        GetContentEditorWarningsArgs.ContentEditorWarning cew = args.Add();
        cew.IsExclusive = true;
        cew.Key = "EditorIsFromAuthorGroup";
        cew.Title = "Editing restricted";
        cew.Text = $"Editing for this item is restricted. Editors must share a role with the original author, in this case <{user?.DisplayName ?? "Unknown Author"}>.";
    }
    private bool _isValidForProcessing()
    {
        if (this._item == null)
            return false;
        if (Context.IsAdministrator)
            return false;
        if (!this._paths.Any<string>((string p) => this._item.Paths.FullPath.ToLower().StartsWith(p)))
            return false;
        return true;
    }
