    var ls = new List<thingy>();
 
    //Add any object that inherits from thingy
    ls.Add(new myAwesomeThingy());
    
    //Or add whatever other type of object that implements myThingy
    ls.Add( new AnotherClassThatInheritsFromMyThingy());
    ls.Add( new WhatThatGuySaid() );
    ls.Add( new Ditto() );
 
    //If you want to get only the items of type myAwesomeThingy do this
    var nls = ls.OfType<myAwesomeThingy>().ToList();
    //this will print one
    Console.WriteLine(nls.Count);
    //This will print out type name "myAwesomeThingy"
    Console.WriteLine(nls[0].GetType());
