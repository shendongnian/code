    var id = 1; // the ID of the person to count chat partners for
    var chatPartnerCount = db.UserMessages
        .Where(x => x.SenderId == id && !x.SenderDelete || x.ReceiverId == id && !x.ReceiverDelete)
        .GroupBy(x => x.SenderId == id ? x.ReceiverId : x.SenderId) // group by the chat partner
        .Count(); // count the number of unique chat partners
