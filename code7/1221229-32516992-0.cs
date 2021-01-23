    private bool _Executed;
    private void OnButtonClick(object sender, EventArgs e)
    {
        if(!_Executed)
        {
            _Executed = true;
            DoOnlyOnce();
        }    
    }
    private void DoOnlyOnce()
    {
        Console.WriteLine("Watch carefully. You'll never see me again.");
    }
