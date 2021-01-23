    Public class Form1 : Form
    {
      private proxyobjecttype _client;
    
    public Form1()
    {
      _client = mywcfnamespace.Proxyobject();
    }
    
    private void someconsumermethod()
    {
      _client.callWCFmethod1();
    }
    }
