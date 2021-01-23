    class PhysicalProperties 
    {
        public double Temp { get; set; }
        public double Vis  { get; set; }
        public double Dens { get; set; }
    }
    
    List<PhysicalProperties> ListPhysicalProperties 
 
    PhysicalProperties fpUnder;
    PhysicalProperties fpOver;
    foreach(PhysicalProperties f in ListPhysicalProperties) 
    {
       if(f.Temp >= temp) 
       {
           fpOver = f;
           break:
       }
       fpUnder = f;
    }
