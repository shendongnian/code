    public Bike(String colour, int gears, Boolean bell)
                    : base (colour){
     ////.......
    public override ToString(){
        string yesNo=(bell==true)? "with one":"and no";
        return string.Format("The {0} bike has {1} {2} bell", colour, gears, yesNo);
    }
    }
 
