    [Browsable(false)]
    public MailSettingsSectionGroup MailSettings { get; private set; }
    [Category(MailSettingsCategory)]
    [DisplayName("Pickup Directory Location")]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The folder where to save email messages to be processed by an SMTP server.")]
    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    public string SmtpPickupDirectoryLocation
    {
        get
        {
            return this.MailSettings.Smtp.SpecifiedPickupDirectory.PickupDirectoryLocation;
        }
        set
        {
            this.MailSettings.Smtp.SpecifiedPickupDirectory.PickupDirectoryLocation = value;
        }
    }
    ...
