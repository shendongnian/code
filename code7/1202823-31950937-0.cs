    static void Main(string[] args)
    {
       IDictionary<string,float> IDico=new Dictionary<string,float>();
       IDico.Add("D1",1);
       IDico.Add("D2",2);
       IDico.Add("D3",3);
       string tempo="D2";
       string outPut = string.Empty;
       foreach(var element in IDico.Keys)
       {
           if(tempo.Contains(element))
           {
               outPut = IDico[element.Index]
           }
       }
       var call = outPut;
    }
