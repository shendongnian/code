    var container = new Container(new Uri("http://localhost/MyApp/odata"));
    var book = new Book(){ISBN = "AXBX"}
    container.AttachTo("Books", book); // add object to entity tracker
    container.DeleteObject(book);
    container.SaveChanges();
