    for (int i = 0; i < 2; i++) {
        User tempUser = new User() {
            ID = null,
            EMail = i + "@" + i + ".de",
            Password = "Test1234",
            JoinedDate = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")
        };
    
        users.InsertOnSubmit(tempUser);
        
    }
    context.SubmitChanges();
