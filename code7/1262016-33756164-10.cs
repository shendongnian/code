      var serialize = new List<Tuple<int, List<string>>>();
            
     for(int i=0;i<tcid.Count();i++)
     {
           var val = new List<string>();
           foreach(var item in model)
           {
               if(tcid[i]==item.TcSetID)
                    val.Add(item.Value);        
           }
           serialize.Add(new Tuple<int,List<string>>(tcid[i],val));
      }
