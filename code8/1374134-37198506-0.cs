    private void FindAndReplace(bool condition)
    {
        if (condition)
        {
            FindAndReplace1(true);
        }
        else
        {
            FindAndReplace2(1);
        }
    }
    
    public void Main()
    {
        ChangeSetting();
        FindAndReplace(conditionA);
        ChangeSettingBack();        
    }
