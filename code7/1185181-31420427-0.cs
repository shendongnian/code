    private void InitializeAudit()
    {
        var octx = ((IObjectContextAdapter) this).ObjectContext;
        HttpContext context = HttpContext.Current;
        octx.SavingChanges +=
            (sender, args) =>
            {
                // context is not null
            };
    }
