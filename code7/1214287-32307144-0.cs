    foreach (var item in data_int)
    {
         if (initializer == 0)
         { initializer = item; continue; }
         else
         {
             counter++;
             if (item == initializer + counter)
                 finalizer = item;
             else
                 {
                     if (initializer != finalizer)
                         data_result.Add(initializer + "A - " + finalizer +
                                             "A");
                     else
                         data_result.Add(initializer + "A");
                      
                     initializer = item;
                     finalizer = item;
                     counter = 0;
               }
         }
    }
    if (initializer != finalizer) // Outside the foreach loop
        data_result.Add(initializer + "A - " + finalizer + "A");
    else
        data_result.Add(initializer + "A");
