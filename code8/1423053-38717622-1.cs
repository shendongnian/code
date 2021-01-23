    string orders = "Total orders are 2222 open orders are 1233 closed are 222";
    List<int> nums = new List<int>();
    StringBuilder sb = new StringBuilder();
    foreach (Char c in orders)
    {
        if (Char.IsDigit(c))
        {
            //append to the stringbuilder if we find a numeric char
            sb.Append(c);
        }
        else
        {
            if (sb.Length > 0)
            {
                nums.Add(Convert.ToInt32(sb.ToString()));
                sb = new StringBuilder();
            }
        }
    }
    if (sb.Length > 0)
    {
        nums.Add(Convert.ToInt32(sb.ToString()));
    }
    //nums now contains a list of the integers in the string
    foreach (int num in nums)
    {
        Debug.WriteLine(num);
    }
