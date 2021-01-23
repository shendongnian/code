    static void Main(string[] args)
    {
       IDictionary<string,float> IDico=new Dictionary<string,float>();
       IDico.Add("D1",1);
       IDico.Add("D2",2);
       IDico.Add("D3",3);
    
       string tempo="D2";
       float outPut = 0.0;
       foreach(var element in IDico.Keys)
       {
        if(tempo.Contains(element in IDico.Keys)
         {
           outPut=IDico[element]
         }
       }
        //Do stuff with outPut
    }
