    public static void ShowContact(repUserObject uo, ContactFormAction action, int contactID)
    {
        CreateContactThread(uo, contactID);
        if (_contactsWindow != null)
        {
            _contactsWindow.BringToFront();
            _contactsWindow.Focus();
            switch (action)
            {
                case ContactFormAction.ViewContact:
                    if (contactID > 0)
                        _contactsWindow.LoadCustomer(contactID); // load the contact
                    break;
                case ContactFormAction.AddNewContact:
                    _contactsWindow.AddCustomer();
                    break;
            }
        }
    }
    private static void CreateContactThread(repUserObject uo, int contactID)
    {
        if (_contactthread == null || !_contactthread.IsAlive)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            _contactthread = new Thread(delegate()
            {
                _contactsWindow = new SetupContacts(uo, contactID);
                _contactsWindow.CerberusContactScreenClosed += delegate { _contactsWindow = null; };
                _contactsWindow.CerberusContactHasBeenSaved += delegate(object sender, ContactBeenSavedEventArgs args)
                {
                    if (CerberusContactHasBeenSaved != null)
                        CerberusContactHasBeenSaved.Raise(sender, args);
                };
                _contactsWindow.Loaded += (sender, e) =>
                {
                    tcs.SetResult(true);
                };
                Application.EnableVisualStyles();
                BonusSkins.Register();
                SkinManager.EnableFormSkins();
                UserLookAndFeel.Default.SetSkinStyle("iMaginary");
                Application.Run(_contactsWindow);
            });
            _contactthread.SetApartmentState(ApartmentState.STA);
            _contactthread.Start();
            tcs.Task.Wait();
        }
    }
