    class PhysicalProperties 
    {
        public double Temp { get; set; }
        public double Vis  { get; set; }
        public double Dens { get; set; }
    }
    
    List<PhysicalProperties> ListPhysicalProperties = new List<PhysicalProperties>(); 
    // add the PhysicalProperties in temp order
 
    PhysicalProperties fpUnder;
    PhysicalProperties fpOver;
    foreach(PhysicalProperties fp in ListPhysicalProperties) 
    {
       if(f.Temp >= temp) 
       {
           fpOver = fp;
           break:
       }
       fpUnder = fp;
    }
    // do the liner interpolation on fpUnder and fpOver  
    // check for possible null
