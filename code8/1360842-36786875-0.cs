    private label1String = String.Empty();
    public FORM2(string arg)
    {
        ...Default Initialization Code...
        label1String = arg;
    }
    private void ChangeLabel2Color()
    {
        if(label1String == "1")
        {
            LABEL2.BackColor = whateverColorYouNeed;
        }
        else
        {
            ...WHATEVER YOU NEED TO DO...
        }
    }
