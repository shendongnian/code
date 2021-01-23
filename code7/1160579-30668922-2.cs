    GroupEmails = group.Email == null ? null : new List<DB.GroupEmail>
                                              {
                                                new DB.GroupEmail
                                                {
                                                  Email = groupt.Email
                                                }
                                              }
