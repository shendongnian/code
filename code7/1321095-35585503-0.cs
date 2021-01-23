    private void AddModifyingCall(ApiCall apiCall, MethodCall methodCall)
    {
        // TODO: this needs scripting
        ////if (RemoveRedundantModifyingCalls)
        ////{
        ////    var before = Evaluate(apiCall, UseDefaultFormatting);
        ////    apiCall.Add(methodCall);
        ////    var after = Evaluate(apiCall, UseDefaultFormatting);
        ////    if (before == after)
        ////    {
        ////        apiCall.Remove(methodCall);
        ////    }
        ////}
    
        apiCall.Add(methodCall);
        return;
    }
