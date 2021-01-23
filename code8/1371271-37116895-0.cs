    var list=correctionQoutas.ToList();
    for(int i=0;i<list.Count())
       {
        if(list[i].Value % 1 != 0)
          { 
           list[i].Value = Convert.ToDouble(string.Format("{0:0.0}", list[i].Value)) ;
          }
       }
