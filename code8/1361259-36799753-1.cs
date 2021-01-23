    void c()
    {
       IndentDebug.WriteLine("I'm in C");
       a();
       b();
       using (IndentDebug id = new IndentDebug("I'm still in C"))
       {
          d();
       }
    }
