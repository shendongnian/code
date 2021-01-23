    static void Main(string[] args)
    {
        var storage = new CompoundStorage("your image.png", false); // open for write
        storage.Properties.Comments = "hello"; // change well-known "comments" property
        storage.CommitChanges();
    }
