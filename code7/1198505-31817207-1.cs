    public event Action SomeEvent;
    public void OnAction()
    {
        var a = this.SomeEvent;
        if (a != null)
        {
            a();
        }
    }
