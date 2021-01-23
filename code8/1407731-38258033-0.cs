         FindItemsResults<Item> fItems = service.FindItems(WellKnownFolderName.Inbox,new ItemView(10));
        PropertySet psSet = new PropertySet(BasePropertySet.FirstClassProperties);
        service.LoadPropertiesForItems(fItems.Items, psSet);
        List<Attachment> atAttachmentsList = new List<Attachment>();
        foreach(Item ibItem in fItems.Items){
            foreach(Attachment at in ibItem.Attachments){
                atAttachmentsList.Add(at);
            }
        }
        ServiceResponseCollection<GetAttachmentResponse> gaResponses = service.GetAttachments(atAttachmentsList.ToArray(), BodyType.HTML, null);
        foreach (GetAttachmentResponse gaResp in gaResponses)
        {
            if (gaResp.Result == ServiceResult.Success)
            {
                if (gaResp.Attachment is FileAttachment)
                {
                    Console.WriteLine("File Attachment");
                }
                if (gaResp.Attachment is ItemAttachment)
                {
                    Console.WriteLine("Item Attachment");
                }
            }
        }
