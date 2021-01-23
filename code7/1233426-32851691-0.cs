    public double this[int i]
    {  
        get
        {
            int index = i - 1;
            if (index < 0 || index >= scores.Count)
            {
                throw new Exception("Invalid CA number get");
            }
            else
                return scores[i]; 
        }
        set
        {
            int index = i - 1;
            if (index < 0 || index > scores.Count)
            {
                throw new Exception("Invalid CA number set");
            }
            else
            { 
                if (index < scores.Count)
                    scores[index] = value;
                else
                    scores.Add(value);
            }
        }
    }
