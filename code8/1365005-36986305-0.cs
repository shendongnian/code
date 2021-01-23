    // fetch some useful metadata about each message in the folder...
    var items = folder.Fetch (0, -1, MessageSummaryItems.UniqueId | MessageSummaryItems.Size | MessageSummaryItems.Flags);
    
    // iterate over all of the messages and fetch them by UID
    foreach (var item in items) {
        var message = folder.GetMessage (item.UniqueId);
    
        Console.WriteLine ("The message is {0} bytes long", item.Size.Value);
        Console.WriteLine ("The message has the following flags set: {0}", item.Flags.Value);
    }
