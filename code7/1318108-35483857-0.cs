    bool inited = false;
    MyStruct? s;    
    while (true)
    {
       foreach( Something foo in ACollection )
          foo.Test();
       if( inited && false == s.HasValue )
          return;
    }
