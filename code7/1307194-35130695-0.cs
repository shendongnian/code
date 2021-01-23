     List<someType> ToRemove=new List<someType>() ; //some type is same type as theList is  
     List<someType> ToAdd=new List<someType>();
    for (int i = 0; i < theList.Count; i++) {
     if(someCircunstances)
         ToRemove.add(component);
     else
         ToAdd.add(component);
    }
     theList=((theList.Except(ToRemove)).Concat(ToAdd)).ToList();
