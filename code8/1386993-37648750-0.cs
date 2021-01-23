    Document doc = new Document(filePath);
    DocumentBuilder builder = new DocumentBuilder(doc);
    // Move cursor to MergeField and remove it
    builder.MoveToMergeField("mf");
    // Create a Bookmark
    builder.StartBookmark("bm");
    // Write something
    builder.Write("Some text");
    builder.EndBookmark("bm");
    // Access content of Bookmark
    Console.WriteLine(doc.Range.Bookmarks["bm"].Text);
