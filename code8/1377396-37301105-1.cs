    List<int> allIDs = new List<int>();
    foreach(string key in keys)
    {
        var query = (from m in db.Messages
                     join r in db.Recievers on m.Id equals r.Message_Id
                     where m.MessageText.Contains(key) || m.Comments.Any(cmt => cmt.CommentText.Contains(key)
                     select m.Id).Distinct();
        allIds.AddRange(query);
    }
