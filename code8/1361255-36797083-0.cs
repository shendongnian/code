    void a()
    {
       using(var id = new IndentedDebug())
       {
           id.trace("I'm in A");
       }
    }
    void b()
    {
       using(var id = new IndentedDebug())
       {
           id.trace("I'm in B");
           a();
       }
    }
