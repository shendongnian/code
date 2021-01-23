    var info = client.Inbox.Fetch (new [] { 4442 }, MessageSummaryItems.Flags | MessageSummaryItems.GMailLabels);
    if (info[0].Flags.Value.HasFlag (MessageFlags.Flagged)) {
        // this message is starred
    }
    if (info[0].Flags.Value.HasFlag (MessageFlags.Draft)) {
        // this is a draft
    }
    if (info[0].GMailLabels.Contains ("Important")) {
        // the message is Important
    }
