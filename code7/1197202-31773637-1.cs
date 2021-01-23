    if (Names == null) 
    {
        lock(_sync)
        {
            if (Names == null)
            {
                Names = new ListClass<string>();
            }
        }
    }
