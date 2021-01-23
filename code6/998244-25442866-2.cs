    bool inProcess = false;
    private void DataGridViewCellDoubleClick(...)
    {
        inProcess = true;
        //Write all your code
       inProcess = false;
    }
    private void Form_Closing(...)
    {
        while(inProcess)
        {
        Application.DoEvents();
        }
    }
