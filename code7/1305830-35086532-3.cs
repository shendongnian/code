    public void RXTask()
    {
        FormUpdater frmUpdt = new FormUpdater(Form1.GUIupdate);
        //other procedures and a loop containing the invoke...
        if (Volatile.Read(ref isLoaded))
        {
            this.Invoke(frmUpdt, new object[]
            {
                devnum, rpm,
                current,
                temperature
            });
        }
    }
