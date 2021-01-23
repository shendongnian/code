    //Number entered by user
    private int _judgeResult
    private int JudgeResult { 
        get 
        {
            return _judgeResult;
        }
        set
        {
            _judgeResult = value;
            if (MaxResult < value) 
                MaxResult = value;
        } 
    }
    // variable where to save the max entered number
    private int _maxresult;
    private int MaxResult {
        get
        {
            return _maxresult;
        }
        set
        {
            _maxResult = value;
        }
    }
