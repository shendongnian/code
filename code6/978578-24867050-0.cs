    List<int> list = new List<int>();
    list.Add(1);
    list.Add(2);
    list.Add(3);
    list.ForEach(elt => {
         if(elt == 2) {
             list.Add(666);
         }
          System.Diagnostics.Debug.Write(elt);
    });
