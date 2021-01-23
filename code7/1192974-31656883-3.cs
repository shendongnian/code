    protected void SubmitOnClick(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        ...
    }
    protected void ValidateRequired(object source, ServerValidateEventArgs args)
    {
        args.IsValid = !string.IsNullOrEmpty(args.Value.Trim());
    }
