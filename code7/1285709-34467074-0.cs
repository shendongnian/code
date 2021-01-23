    public void DoSomething(Action<string> Callback){
       var result = getMyString();
       Callback(result); 
    }
    public void DoSomething(Action<string> CallBack, List<string> Parms){
        var sb = new StringBuilder();        
        Parms.ForEach(p=> sb.Append(Parse(p));
        Callback(sb.ToString());
    }
         
