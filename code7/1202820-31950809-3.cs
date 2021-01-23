    static void Main(string[] args)
    {
       IDictionary<string,float> IDico=new Dictionary<string,float>();
       IDico.Add("D1",1);
       IDico.Add("D2",2);
       IDico.Add("D3",3);
    
       string tempo="D2";
    
       if(IDico.Contains(tempo))
         {
           var outPut=IDico[tempo];
         }
       //Do stuff with outPut
     }
