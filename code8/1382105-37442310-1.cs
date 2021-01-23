    var addedRecipients = oldEmailRecipients.SelectMany(e=>
                                             {
                                              var result= new List<EmailRecipient>();
                                              if(!string.IsNullOrWhiteSpace(e.EmailAddress1))
                                              {
                                                 result.Add(new EmailRecipient
                                                                {
                                                                  UserName = e.UserName,
                                                                  EmailAddress = e.EmailAddress1});
                                              }
                                              if(!string.IsNullOrWhiteSpace(e.EmailAddress2))
                                              {
                                                 result.Add(new EmailRecipient
                                                                {
                                                                    UserName = e.UserName,
                                                                    EmailAddress = e.EmailAddress2});
                                              }
                                              return result;
                                             });
