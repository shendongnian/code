    List<ContentProviderOperation> ops = new List<ContentProviderOperation>();
    int rawContactInsertIndex = ops.Count;
    
    ops.Add(ContentProviderOperation.NewInsert(Android.Provider.ContactsContract.RawContacts.ContentUri)
    	.WithValue(Android.Provider.ContactsContract.RawContacts.InterfaceConsts.AccountType, null)
    	.WithValue(Android.Provider.ContactsContract.RawContacts.InterfaceConsts.AccountName, null).Build());
    ops.Add(ContentProviderOperation
    	.NewInsert(Android.Provider.ContactsContract.Data.ContentUri)
    	.WithValueBackReference(Android.Provider.ContactsContract.Data.InterfaceConsts.RawContactId,rawContactInsertIndex)
    	.WithValue(Android.Provider.ContactsContract.Data.InterfaceConsts.Mimetype, Android.Provider.ContactsContract.CommonDataKinds.StructuredName.ContentItemType)
    	.WithValue(Android.Provider.ContactsContract.CommonDataKinds.StructuredName.DisplayName, "Vikas Patidar") // Name of the person
    	.Build());
    ops.Add(ContentProviderOperation
    	.NewInsert(Android.Provider.ContactsContract.Data.ContentUri)
    	.WithValueBackReference(
    		ContactsContract.Data.InterfaceConsts.RawContactId, rawContactInsertIndex)
    	.WithValue(Android.Provider.ContactsContract.Data.InterfaceConsts.Mimetype, Android.Provider.ContactsContract.CommonDataKinds.Phone.ContentItemType)
    	.WithValue(Android.Provider.ContactsContract.CommonDataKinds.Phone.Number, "9999999999") // Number of the person
    	.WithValue(Android.Provider.ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Type, "mobile").Build()); // Type of mobile number  
    
    // Asking the Contact provider to create a new contact                 
    try {
    	ContentResolver.ApplyBatch(ContactsContract.Authority, ops);
    } catch (Exception ex) {
    	Toast.MakeText(this, "Exception: " + ex.Message, ToastLength.Long).Show();
    }
