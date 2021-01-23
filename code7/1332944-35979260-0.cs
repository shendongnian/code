                PropertySet psPropSet = new PropertySet(BasePropertySet.FirstClassProperties);
            psPropSet.Add(ItemSchema.MimeContent);
            foreach (Attachment attachment in CurrentMessage.Attachments)
            {
                if (attachment is ItemAttachment)
                {
                    attachment.Load();
                    if (((ItemAttachment)attachment).Item is EmailMessage)
                    {
                        EmailMessage ebMessage = ((ItemAttachment)attachment).Item as EmailMessage;
                        foreach (Attachment ebAttachment in ebMessage.Attachments)
                        {
                            if (ebAttachment is ItemAttachment)
                            {
                                Attachment[] LoadAttachments = new Attachment[1];
                                LoadAttachments[0] = ebAttachment;
                                ServiceResponseCollection<GetAttachmentResponse> getAttachmentresps = service.GetAttachments(LoadAttachments, BodyType.HTML, psPropSet);
                                foreach (GetAttachmentResponse grResp in getAttachmentresps)
                                {
                                    EmailMessage msg = ((ItemAttachment)grResp.Attachment).Item as EmailMessage;
                                    msg.Load(new PropertySet(ItemSchema.MimeContent));
                                    byte[] content = msg.MimeContent.Content;
                                }
                            }
                        }
                    }
                }
            }
