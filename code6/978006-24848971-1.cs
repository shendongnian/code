    private void button1_Click(object sender, EventArgs e)
    {
      // declaration
      Dictionary<string, Action> dictionaryOfEvents = new Dictionary<string, Action>();
       // test data
      dictionaryOfEvents.Add("Test1", delegate() { testMe1(); });
      dictionaryOfEvents.Add("Test2", delegate() { testMe2(); });
      dictionaryOfEvents.Add("Test3", delegate() { button2_Click(button2, null); });
  
      // usage 1
      foreach(string a in dictionaryOfEvents.Keys )
        {  Console.Write("Calling "  + a  +  ":"); dictionaryOfEvents[a]();}
      // usage 2
      foreach(Action a in dictionaryOfEvents.Values) a();
    
      // usage 3
      dictionaryOfEvents["test2"]();
   
    }
    void testMe1() { Console.WriteLine("One for the Money"); }        
    void testMe2() { Console.WriteLine("One More for the Road"); }
