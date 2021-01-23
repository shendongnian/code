    using System.Runtime.InteropServices;
    
    try
    {
        MLApp.MLApp matlab = 
            (MLApp.MLApp)Marshal.GetActiveObject("Matlab.Desktop.Application");
    }
    catch (System.Runtime.InteropServices.COMException ex)
    {
        //this happens if no Matlab instances were running
        MessageBox.Show(ex.Message, ex.GetType().ToString());
    }
