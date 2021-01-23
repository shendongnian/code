    class PhysicalProperties 
    {
        public double Temp { get; set; }
        public double Vis  { get; set; }
        public double Dens { get; set; }
    }
    
    List<PhysicalProperties> ListPhysicalProperties 
 
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
