    ...
    //newUser.Invoke("Put", new object[] { "userAccountControl", "512" }); <-- Remove this
    newUser.CommitChanges();
    newUser.Invoke("SetPassword", model.Password);
    newUser.Properties["userAccountControl"].Value = 512;
    newUser.CommitChanges();
