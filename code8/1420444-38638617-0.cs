    // Declared at class scope
    private int whichMethod = 1;
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (whichMethod == 1)
        {
            method1();
            whichMethod = 2;
        }
        else
        {
            method2();
            whichMethod = 1;
        }
    }
