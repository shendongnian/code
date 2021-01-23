    public void TestMethod (string name, Action action) {
     if(name == "Lambda") {
       action.Invoke ();
     }
    }
