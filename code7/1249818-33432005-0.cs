    internal void AddFileToListView(String sFile)
        {
            IDataItem idiParentWorkItem = this.DataContext as IDataItem;
            EnterpriseManagementObject emoWorkItem = emg.EntityObjects.GetObject<EnterpriseManagementObject>((Guid)idiParentWorkItem["$Id$"], ObjectQueryOptions.Default);
            EnterpriseManagementObject emoUser = emg.EntityObjects.GetObject<EnterpriseManagementObject>((Guid)ConsoleContextHelper.Instance.CurrentUser["$Id$"], ObjectQueryOptions.Default);
            //System.SupportingItem.Library; ManagementPack ID: 23e3ae8e-1981-8560-2e55-8730cbc04965
            ManagementPack mpSupporting =
               emg.ManagementPacks.GetManagementPack(new Guid("23e3ae8e-1981-8560-2e55-8730cbc04965"));
            //Get the System.FileAttachment class
            ManagementPackClass mpcAttachment = emg.EntityTypes.GetClass("System.FileAttachment", mpSupporting);
            //Get attachment details
            string sExt = Path.GetExtension(sFile);
            string sAttachmentName = Path.GetFileNameWithoutExtension(sFile);
            //Create new stream and read file into memory
            MemoryStream ms = new MemoryStream();
            using (FileStream fs = File.OpenRead(sFile))
            {
                ms.SetLength(fs.Length);
                fs.Read(ms.GetBuffer(), 0, (int)fs.Length);
            }
            //Did we get any data?
            if (ms != null && ms.Length != 0)
            {
                //Reset stream position
                ms.Position = 0;
                //Create a new attachment
                CreatableEnterpriseManagementObject cemoAttachment = new CreatableEnterpriseManagementObject(emg, mpcAttachment);
                //Create a new attachment relationship from SupportingItem -> File Attachment (via "HasFileAttachment: ID =aa8c26dc-3a12-5f88-d9c7-753e5a8a55b4)
                //DisplayName : Has File Attachment
                //Source      : System.WorkItem
                //Target      : System.FileAttachment
                ManagementPackRelationship relAttachment =
                emg.EntityTypes.GetRelationshipClass(new Guid("aa8c26dc-3a12-5f88-d9c7-753e5a8a55b4"));
                CreatableEnterpriseManagementRelationshipObject cemroAttachment =
                    new CreatableEnterpriseManagementRelationshipObject(emg, relAttachment);
                //Create a new added by user relationship
                // ID: ffd71f9e-7346-d12b-85d6-7c39f507b7bb
                // DisplayName : Added By User
                //Source      : System.FileAttachment
                //Target      : System.User
                ManagementPackRelationship relAddedByUser =
                emg.EntityTypes.GetRelationshipClass(new Guid("ffd71f9e-7346-d12b-85d6-7c39f507b7bb"));
                CreatableEnterpriseManagementRelationshipObject cemroAddedByUser =
                    new CreatableEnterpriseManagementRelationshipObject(emg, relAddedByUser);
                //Set properties of attachment
                string sFileName = sAttachmentName;
                if (sExt != "") sFileName += sExt;
                cemoAttachment[mpcAttachment, "AddedDate"].Value = DateTime.UtcNow;
                cemoAttachment[mpcAttachment, "DisplayName"].Value = sFileName;
                cemoAttachment[mpcAttachment, "Extension"].Value = sExt;
                cemoAttachment[mpcAttachment, "Content"].Value = ms;
                cemoAttachment[mpcAttachment, "Size"].Value = ms.Length;
                cemoAttachment[mpcAttachment, "Description"].Value = sFileName;
                cemoAttachment[mpcAttachment, "Id"].Value = Guid.NewGuid().ToString();
                //Set the source and target for the attachment and save (this must be done first)
                cemroAttachment.SetSource(emoWorkItem);
                cemroAttachment.SetTarget(cemoAttachment);
                ////Set the added by user relationship (this must done after the previous relationship)
                cemroAddedByUser.SetSource(cemoAttachment);
                cemroAddedByUser.SetTarget(emoUser);
                cemroAttachment.Commit();
                cemroAddedByUser.Commit();
                EnterpriseManagementObjectDataType emoDataType = new EnterpriseManagementObjectDataType(mpcAttachment);
                IDataItem item = emoDataType.CreateProxyInstance(cemoAttachment);
                Collection<IDataItem> items = lvAttachedRiskRelFiles.ItemsSource as Collection<IDataItem>;
                if (!items.Contains(item))
                    items.Add(item);
            }
        }
