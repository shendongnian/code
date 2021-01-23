    var tempUsers = Enumerable.Range(0, 2)
                          .Select(i => new User{
                                       ID = null,
                                       EMail = i + "@" + i + ".de",
                                       Password = "Test1234",
                                       JoinedDate = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")
                          });
    
    users.InsertAllOnSubmit(tempUsers);
    context.SubmitChanges();
