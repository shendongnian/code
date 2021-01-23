    public void Use()
    {
        var dt = ReadExcelToTable("....The Path....");
        var myDt = ChangeDt(dt);
        for(i=0; i<=10; i++)
        {
           DrawCircuits("name", 1, 2, i, dt);
        }
    }
