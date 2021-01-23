    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            NotifierService.OnOk -= Notify;
        }
        // default
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
