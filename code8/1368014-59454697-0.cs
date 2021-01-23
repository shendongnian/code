 C#
public void SendCommand(string command, params object[] args)
{
    AcadApplication app = GetActiveApp();
    AcadDocument acDoc = app.ActiveDocument;
    // Without arguments
    acDoc.SendCommand("command");
    // With arguments
    acDoc.SendCommand("command args[2], args[1], args[2]");
}
So you would be able to call your plugin like this:
 C#
acDoc.SendCommand("yourPluginCommandName layerName");
