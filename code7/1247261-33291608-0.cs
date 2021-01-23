                var uri = CalendarContract.Calendars.ContentUri;
                ContentValues val = new ContentValues();
                val.Put(CalendarContract.Calendars.InterfaceConsts.AccountName, AccountName);
                val.Put(CalendarContract.Calendars.InterfaceConsts.AccountType, CalendarContract.AccountTypeLocal);
                val.Put(CalendarContract.Calendars.Name, "My Calendar");
                val.Put(CalendarContract.Calendars.InterfaceConsts.CalendarDisplayName, "Silverspot");
                val.Put(CalendarContract.Calendars.InterfaceConsts.CalendarColor, Android.Graphics.Color.Red);       
                val.Put(CalendarContract.Calendars.InterfaceConsts.OwnerAccount, AccountName);
                val.Put(CalendarContract.Calendars.InterfaceConsts.Visible, true);
                val.Put(CalendarContract.Calendars.InterfaceConsts.SyncEvents, true);
                uri = uri.BuildUpon()
                    .AppendQueryParameter(CalendarContract.CallerIsSyncadapter, "true")
                    .AppendQueryParameter(CalendarContract.Calendars.InterfaceConsts.AccountName, AccountName)
                    .AppendQueryParameter(CalendarContract.Calendars.InterfaceConsts.AccountType, CalendarContract.AccountTypeLocal)
                    .Build();
                var calresult = ContentResolver.Insert(uri, val);
