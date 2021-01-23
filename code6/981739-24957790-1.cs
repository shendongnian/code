    var bas = new Base();
    var der = new Derived();
    bas.Hidden(); //This outputs Base!
    der.Hidden(); //This outputs Derived
    ((Base)der).Hidden(); 
    //The above outputs Base! because you are essentially referencing the hidden method!
    //Both the below output Overrideable DERIVED 
    der.Overrideable();
    ((Base)der).Overrideable();
