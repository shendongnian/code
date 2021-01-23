    //The desktop progID only supports single-instance operation
    Type MatlabType = Type.GetTypeFromProgID("Matlab.Desktop.Application");
    MLApp.MLApp matlab = (MLApp.MLApp)Activator.CreateInstance(MatlabType);
    
    //check that we have a valid instance
    if (matlab == default(MLApp.MLApp))
    {
        MessageBox.Show("Matlab com object is null", "Error");
        return;
    }
    //make Matlab do something (give focus to command window)
    try
    {
        matlab.Execute("commandwindow");
    }
    catch (System.Runtime.InteropServices.COMException ex)
    {
        //something went wrong with the COM call
        //such as Matlab getting killed and is no longer running
        MessageBox.Show(ex.Message, ex.GetType().ToString());
    }
    
