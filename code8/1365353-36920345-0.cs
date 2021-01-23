    public class myClass 
    {
       public string PropertyToExpose {get; set;}
       [ScriptIgnore]
       public string PropertyToNOTExpose {get; set;}
       public string Otherthings {get; set;}
    }
