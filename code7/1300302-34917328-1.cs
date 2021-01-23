    public void TakeTwo(int value1, int value2)
    {
        CommonCode();
        baseAPI.GetValues(value1, value2);
    }
    public void TakeTwo(string value1, string value2)
    {
        CommonCode();
        baseAPI.GetValues(value1, value2);
    }
    private void CommonCode()
    {
        // Things you want to do in both methods
    }
