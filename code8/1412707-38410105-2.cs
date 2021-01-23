    class ActionTrigger
    {
        public Action Action { get; set; }
        public Trigger Trigger { get; set; }
    }
    var actionAndTrigger = (from t in sequence.Triggers
                            from a in t.Actions
                            where a.ActionId == actionId
                            select new ActionTrigger { Action = a, Trigger = t })
                            .FirstOrDefault();
