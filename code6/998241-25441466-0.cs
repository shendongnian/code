    bool inProcess = false;
    
    private void DataGridViewCellDoubleClick(...)
    {
       inProcess = true;
       //Write all ur code
       inProcess = false;
    }
    
    private void Form_Closing(...)
    {
       e.Cancel = inProcess;
    }
