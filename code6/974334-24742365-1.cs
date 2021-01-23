    public class MyHostObject
    {
        public List<int> list_of_ints;
        public int an_int = 23;
    }
    
    var hostObject = new MyHostObject();
    hostObject.list_of_ints = new List<int>();
    hostObject.list_of_ints.Add(2);
    var engine = new ScriptEngine(new[] { hostObject.GetType().Assembly.Location });
    
    // passing reference to hostObject upon session creation
    var session = Session.Create(hostObject);
    
    // prints `24` to console
    engine.Execute(@"System.Console.WriteLine(an_int + list_of_ints.Count);", 
                   session); 
