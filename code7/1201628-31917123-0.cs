    var bs = A.SelectMany().Where().Select(b=>b.Id).OrderBy();
    int current = -1, maxB = -1;   // make sure it is stub Id
    int currentCount = 0, maxCount = 0;
    foreach(var b in bs)
    {
        if (b != current)
        {
             // check if previous was max
             if (currentCount > maxCount)
             {
                  maxB = current;
                  maxCount = currentCount;
             }
             // change current
             current = b;
             currentCount = 0;
        }
        currentCount ++;
    }
