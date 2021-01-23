    using Autodesk.AutoCAD.Interop;
    [..]
    void button1_Click(object sender, EventArgs e)
    {
        const uint MK_E_UNAVAILABLE = 0x800401e3;
        AcadApplication acad;
        try
        {
            // Try to get a running instance of AutoCAD 2016
            acad = (AcadApplication) Marshal.GetActiveObject("AutoCAD.Application.20.1");
        }
        catch (COMException ex) when ((uint) ex.ErrorCode == MK_E_UNAVAILABLE)
        {
            // AutoCAD is not running, we start it
            acad = (AcadApplication) Activator.CreateInstance(Type.GetTypeFromProgID("AutoCAD.Application.20.1"));
        }
        activeDocument = acad.ActiveDocument;
        activeDocument.EndCommand += ActiveDocument_EndCommand;
        activeDocument.SendCommand("YOURCOMMAND ");
    }
    void ActiveDocument_EndCommand(string CommandName)
    {
        if (CommandName != "YOURCOMMAND") return;
        try
        {
            double value = activeDocument.GetVariable("USERR1");
            // Process the value
            MessageBox.Show(value.ToString());
        }
        finally
        {
            // Remove the handler
            activeDocument.EndCommand -= ActiveDocument_EndCommand;
        }
    }
