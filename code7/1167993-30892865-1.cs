    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        if (this.isClosingViaOkButton)
        {
            // ...do your committing.
        }
        else
        {
            // ...do your rollback.
        }
    }
