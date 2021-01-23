    Doc document = new Doc();
    ...
    ...
    User usr = new User() {Name = "Temp", Info = "Some info.."};
    context.Users.Add(usr);
    document .Users.Add(usr );
    context.AddToDocuments(document);
    context.SaveChanges();
