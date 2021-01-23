        FolderId  folderid= new FolderId(WellKnownFolderName.Inbox,"MailboxName");    
        Folder Inbox = Folder.Bind(service,folderid);  
        ItemView ivItemView =  new ItemView(1) ;     
        FindItemsResults<Item> fiItems = service.FindItems(Inbox.Id,ivItemView);
        if(fiItems.Items.Count == 1){  
        EmailMessage mail = new EmailMessage(service);   
        EmailMessage OriginalEmail = (EmailMessage)fiItems.Items[0];
        PropertySet  psPropset= new PropertySet(BasePropertySet.IdOnly);    
        psPropset.Add(ItemSchema.MimeContent);
        psPropset.Add(ItemSchema.Subject);
        OriginalEmail.Load(psPropset);  
        ItemAttachment Attachment = mail.Attachments.AddItemAttachment<EmailMessage>();
        Attachment.Item.MimeContent = OriginalEmail.MimeContent;  
        ExtendedPropertyDefinition PR_Flags = new ExtendedPropertyDefinition(3591, MapiPropertyType.Integer);    
        Attachment.Item.SetExtendedProperty(PR_Flags,"1");    
        Attachment.Name = OriginalEmail.Subject;  
        mail.Subject = "See the Attached Email";  
        mail.ToRecipients.Add("glen.scales@domain.com");
        mail.SendAndSaveCopy();     
