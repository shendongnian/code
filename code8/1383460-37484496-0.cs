            ExtendedPropertyDefinition ClutterFolderEntryId = new ExtendedPropertyDefinition(new Guid("{23239608-685D-4732-9C55-4C95CB4E8E33}"), "ClutterFolderEntryId", MapiPropertyType.Binary);
            PropertySet iiips = new PropertySet();
            iiips.Add(ClutterFolderEntryId);
            String MailboxName = "jcool@domain.com";
            FolderId FolderRootId = new FolderId(WellKnownFolderName.Root, MailboxName);
            Folder FolderRoot = Folder.Bind(service, FolderRootId, iiips);
            Byte[] FolderIdVal = null;
            if (FolderRoot.TryGetProperty(ClutterFolderEntryId, out FolderIdVal))
            {
                AlternateId aiId = new AlternateId(IdFormat.HexEntryId, BitConverter.ToString(FolderIdVal).Replace("-", ""), MailboxName);
                AlternateId ConvertedId = (AlternateId)service.ConvertId(aiId, IdFormat.EwsId);
                Folder ClutterFolder = Folder.Bind(service, new FolderId(ConvertedId.UniqueId));
                Console.WriteLine("Unread Email in clutter  : " + ClutterFolder.UnreadCount);
            }
