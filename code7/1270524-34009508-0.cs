    {    
        string s;
        int maxValue=-1, temp=-1;
        using(System.IO.StreamReader in = new System.IO.StreamReader(DataFile))
        {
            while (in.Peek() >= 0) 
            {
                s = in.ReadLine();
                if(int.tryParse(s.split(",")[1], out temp)
                {
                    if(temp>maxValue)
                       maxValue = temp;
                }
            }
        }
    }
