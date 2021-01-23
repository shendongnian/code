    class Legacy
    {  public void DoThis() 
       { ... }
       public void DoThat()
       { ... }
    }
    class Wrapper 
    {   Legacy _legacy;
        public Wrapper() { _legacy = new Legacy(); }
        public void DoThis()
        {
           try {
               _legacy.DoThis();
           }
           catch (PolicyViolationException exception) {
               //ignore
           }
        }
     ...
    }
