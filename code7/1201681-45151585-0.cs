     private async void SendEmailButton_Click(object sender, RoutedEventArgs e)
            {
                EmailMessage emailMessage = new EmailMessage();
                emailMessage.To.Add(new EmailRecipient("***@***.com"));
                string messageBody = "Hello World";
                emailMessage.Body = messageBody;
                StorageFolder MyFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                StorageFile attachmentFile =await MyFolder.GetFileAsync("MyTestFile.txt");
                if (attachmentFile != null)
                {
                    var stream = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromFile(attachmentFile);
                    var attachment = new Windows.ApplicationModel.Email.EmailAttachment(
                             attachmentFile.Name,
                             stream);
                    emailMessage.Attachments.Add(attachment);
                }
                await EmailManager.ShowComposeNewEmailAsync(emailMessage);           
            }
