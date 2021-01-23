    public static Dictionary<int, List<Message>> SynchronizedChatMessages(List<Message> messages, Dictionary<int, int> data)
    {
        List<Predicate<Message>> predList = new List<Predicate<Message>>();
        //Built of list of indivIdual predicates
        foreach (var x in data)
        {
            var IdMessage = x.Key;
            var lastMessageId = x.Value;
            Predicate<Message> pred = m => m.IdGroup.Id == IdMessage && m.Id > lastMessageId;
            predList.Add(pred);
        }
        //compose the predicates
        Predicate<Message> compositePredicate = m =>
        {
            bool ret = false;
            foreach (var pred in predList)
            {
                //If any of the predicates is true, the composite predicate is true (OR)
                if (pred.Invoke(m) == true) { ret = true; break; }
            }
            return ret;
        };
        //do the query
        var messagesFound = messages.Where(m => compositePredicate.Invoke(m)).ToList();
        //get the individual distinct IdGroupIds
        var IdGroupIds = messagesFound.Select(x => x.IdGroup.Id).ToList().Distinct().ToList();
        //Create dictionary to return
        Dictionary<int, List<Message>> result = new Dictionary<int, List<Message>>();
        foreach (int i in IdGroupIds)
        {
            result.Add(i, messagesFound.Where(m => m.IdGroup.Id == i).ToList());
        }
        return result;
    }
