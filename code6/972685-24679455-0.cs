    public class Host : ObservableObject
    {
        public M1 Instance {get; set;}
    }
    
    ...
    
    var host = new Host();
    host.Instance = new M1();
    host.Instance = new M1(); // Reassigned, Host will see the change.
