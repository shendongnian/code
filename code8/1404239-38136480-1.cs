    class PhysicalProperties 
    {
        public decimal Temp { get; set; }
        public decimal Vis  { get; set; }
        public decimal Dens { get; set; }
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
