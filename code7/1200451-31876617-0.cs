    int[] input = new int[] { 1, 2, 3, -1, 1, 3, -2, 3, 4 };
    List<int> sums = new List<int>();
    int tmp_sum = 0;
    
    foreach(int _element in input)
    {
        if(_element <= 0)
        {
            sums.Add(tmp_sum);
            tmp_sum = 0;
        }
        else
        {
            tmp_sum += _element;
        }    
    }
    sums.Add(tmp_sum);
    
    int[] result = sums.ToArray();
