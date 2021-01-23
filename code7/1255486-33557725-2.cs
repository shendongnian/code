    //Number entred by user
    private static int _intJudgeResult;
    private static int intJudgeResult 
    { 
        get
        {
            return _intJudgeResult; //EDIT: Missed the _ before
        } 
        set
        {
            intJudgeResult = value;
            maxResult = intJudgeResult;
        }
    // varibale where to save the max entred number
    private static int _maxresult = 0;
    private static int maxResult 
    {
        get
        {
            return _maxresult;
        }
        set
        {
            if (value > intJudgeResult )
                _maxResult = value;
        }
    }
