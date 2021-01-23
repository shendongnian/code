    var dict = objList.ToDictionary( k => k.Name, v => v);
    dict.Dump();
    
    var values = new int[6] {12, 18, 9, 56, 112, 187};
    // enumerator that keeps track where we are
    var valuesEnumerator = values.GetEnumerator();
    
    // set all to -1
    foreach(var v in dict.Values) v.Value =-1;
    const int scale = 4;
    //group
    for(int g = 1;  g <= scale ; g++)
    {
       // section
       for(int s = 1;  s <= scale; s++)
       {
          //item
          for(int i = 1; i <= scale; i++)
          {
                // build a key
                var key = String.Format("{0}{1}{2}",i,s,g);
                // check if that key exist
                if (dict.Keys.Contains(key))
                {
                    // as long as there numbers in the values array
                    if (valuesEnumerator.MoveNext()) 
                    {
                        // assign that value
                        dict[key].Value = (int) valuesEnumerator.Current;
                    }
                }
          }
       }
    }
