    for(int i = sequence.Count; i >= 0; i--)
    {   
        if(i % step == 1)
        {
            sequence.RemoveAt(i);
        }
    }
