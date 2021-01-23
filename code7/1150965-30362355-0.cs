        var visits = JsonConvert.DeserializeObject<VisitorDetails[]>(json_string);
        foreach (var visit in visits)
        {
            Console.WriteLine("Visitor: {0}", visit.visitorId);
            foreach (var detail in visit.actionDetails)
            {
                Console.WriteLine("  Action: {0}", detail.type);
                foreach (var cv in detail.customVariables.Where(x => x.Value.ContainsKey("customVariablePageName1")))
                {
                    Console.WriteLine("    Custom variable #{0}", cv.Key);
                    Console.WriteLine("    Value: {0}", cv.Value["customVariablePageValue1"]);
                }
            }
        }
    Which resembles your view's `foreach`, and will produce the following output:
        Visitor: a393fed00271f588
          Action: action
            Custom variable #1
            Value: http://mysite.info/p
