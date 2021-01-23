    int[] input = new int[] { 1, 2, 3, -1, 1, 3, -2, 3, 4 };
    // a list is easier to use dynamic sizes
    List<int> sums = new List<int>();
    // the sum to the next negative number
    int tmp_sum = 0;
    
    // loop through
    foreach(int _element in input)
    {
        if(_element <= 0 && tmp_sum > 0)
        {
            // negative element found, so save the sum if it is bigger than 0
            sums.Add(tmp_sum);
            tmp_sum = 0;
        }
        else
        {
            // keep summing up
            tmp_sum += _element;
        }    
    }
    //save the last one, if it is bigger than 0
    if(tmp_sum > 0)
        sums.Add(tmp_sum);
    
    // convert to an array
    int[] result = sums.ToArray();
