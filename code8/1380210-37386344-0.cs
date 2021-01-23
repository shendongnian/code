    public int sumofD(int n)
    {
        string str = n.ToString();
        int total = 0;
        foreach (char c in str.ToCharArray())
        {
            total += int.Parse(c+"");
        }
        if (total > 9) total = sumofD(total);
        return total;
    }
