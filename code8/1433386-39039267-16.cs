    public IEnumerable<MoveOption> movepion(schaken.pion pion, int row, int column)
    {
        List<MoveOption> options = new List<MoveOption>();
    
        if(/*some condition*/)
        {
            options.Add(new MoveOption{ X = 1, Y = 2 });
        }
    
        if(/*some condition*/)
        {
            options.Add(new MoveOption{ X = 5, Y = 7 });
        }
    
        //Rest of options
    
        return options;
    }
