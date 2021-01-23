            PropertySet psPropSet = new PropertySet(BasePropertySet.FirstClassProperties);
            psPropSet.Add(ItemSchema.MimeContent);
            var completeEmailMessage = EmailMessage.Bind(_service, emailId, psPropSet);
            var mimeContent = completeEmailMessage.MimeContent;
            string tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".eml");
            using (var fileStream = new FileStream(tempFile, FileMode.Create))
            {
                fileStream.Write(mimeContent.Content, 0, mimeContent.Content.Length);
            }
