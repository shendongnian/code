    public void Process(GetContentEditorWarningsArgs args)
    {
        string displayName;
        this._item = args.Item;
        if (!this._isValidForProcessing())
            return;
        User user = null;
        List<string> creatorRoles = this._getRolesForUser(this._item.Statistics.CreatedBy, out user);
        List<string> editorRoles = this._getRolesForUser(Context.User);
        // compare creator's roles with current editor to find a match
        if ( creatorRoles.Any() && editorRoles.Any() && editorRoles.Any( r => creatorRoles.Contains(r) ) )
            return;
        // if we haven't already aborted, add a warning to display and block editing
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
