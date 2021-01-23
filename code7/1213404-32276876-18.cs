    (new Action<int>(x => { Console.WriteLine(x); }))(1);
    (new Action(() => { Console.WriteLine("asd1"); }))();
    ((Console.WriteLine))("asd2");
    ((Action)null)();
    
    Action a = null; 
    (true ? a : null)();
    ((a))();
    
