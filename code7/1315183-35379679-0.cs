        int index=-1;
        Parallel.For(0, list.Count - 1, i =>
        {
          if (list[i] == "D" && list[i + 1] == "E")
          {
              Interlocked.Exchange(ref index, i);
          }
        }); 
    //after the loop, if index!=-1, sublist was found and starts at index position
