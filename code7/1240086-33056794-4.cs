     [TestMethod]
        public void TestMethodParentChild()
        {
            using (var context = new MyContext())
            {
                //put some data in the Db which is linked
                //---------------------------------
                var emailMessage = new EmailMessage
                {
                    FromEmailAddress = "sss",
                    Message = "test",
                    Content = "hiehdue",
                    ReceivedDateTime = DateTime.Now,
                    CreateOn = DateTime.Now
                };
                var emailAttachment = new EmailAttachment
                {
                    EmailMessageId = 123,
                    OrginalFileName = "samefilename",
                    ContentLength = 3,
                    File = new byte[123]
                };
                emailMessage.EmailAttachments.Add(emailAttachment);
                context.EmailMessages.Add(emailMessage);
                context.SaveChanges();
                //---------------------------------
                var firstEmail = context.EmailMessages.FirstOrDefault(x => x.Content == "hiehdue");
                if (firstEmail != null)
                {
                    //change the parent if you want
                    //foreach child change if you want
                    foreach (var item in firstEmail.EmailAttachments)
                    {
                        item.OrginalFileName = "I am the shit";
                    }
                }
                context.SaveChanges();
            }
        }
