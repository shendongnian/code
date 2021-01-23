    var items = new List<PostItem>();
    for (int i = 0; i != 10; ++i)
    {
        var m = new PostItem(service);
        m.Subject = "Note " + i.ToString();
        m.Body = new MessageBody(BodyType.Text, "A test note");
        m.Save();
    }
