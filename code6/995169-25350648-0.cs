    Dictionary<string, Flags> test = new Dictionary<string, Flags> ();
    
    void Populate()
    {
       Flags test2 = new Flags();
       var returnx = test2.Return();
       test.Add("Levels", returnx);
    }
    
    internal class Flags
    {
       Dictionary<string,string> Flags = new Dictionary<string,string>();
    
       public Dictionary<string, string> Return()
       {
         Flags.Add("reservation", "a");
         Flags.Add("generic", "b");
         // Etc...
         return Flags;
       }
    }
