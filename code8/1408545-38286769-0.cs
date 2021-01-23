    static void Main(string[] args) {
    //Data _dummy = new Data(); // reference a type in the other assembly
    AppDomain.CurrentDomain.Load("Assembly2"); // manually load into the current domain
    var config = new JobHostConfiguration();
            
    var host = new JobHost(config);
    host.RunAndBlock(); }
