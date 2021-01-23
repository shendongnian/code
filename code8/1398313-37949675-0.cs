    class YourClass
    
    { 
    public integer PPID {get;set;}
    public string Name {get;set;}
    }
    
    static void Main()
    {
    // Just an example...
    // SQL command already executed, data readers declared and so on...
    
    int i=0;
    YourClass[] arr = new YourClass[];
    while(yourDataReader.Read()){
      arr[i] = new YourClass();
      arr[i].PPID = yourDataReader.GetInt32(0);
      arr[i].Name = yourDataReader.GetString(1);
    }
