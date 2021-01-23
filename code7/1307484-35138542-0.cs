    var _triggerlist = TriggerOn.GetType().GetProperties().Where(x => x.Name.Contains("Delay"));
    
    if (_triggerlist.Any(x => x.GetValue(x) == t.TriggerOn)
    {
        //dowork
    }
