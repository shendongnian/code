    List<double> ElementList = new List<double>(); // making it a list so the size will be dynamic
    for(int i =0; i<data.GetLength(1);i++)
    {
     ElementList.Add(data[r,i]); // adding all the elements to the list
    }
    v[r] = new Vector(ElementList.toArray());
