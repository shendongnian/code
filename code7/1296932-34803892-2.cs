    class C
    {
        protected Member mem;
        protected Robot bot;
    }
    private class Robot : C
    {
       public void function() { 
          base.mem...  // here you can use the base classes mem and bot
       };
    }
