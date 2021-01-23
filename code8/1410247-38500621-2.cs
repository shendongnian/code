    namespace AddinMultiLineWatch
    {
    public class Connect : IDTExtensibility2, IDTCommandTarget
    {
    	//ADD THESE MEMBER VARIABLES
    	//private DebuggerEvents _debuggerEvents = null;
    	//private _dispDebuggerEvents_OnEnterBreakModeEventHandler DebuggerEvents_OnEnterBreakMode;
    	private Window _watchWindow = null;
    	private CommandEvents _objCommandEvents;
    	private bool _isRecursive = false;
    	public Connect()
    	{
    	}
    
    	public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
    	{
    		_applicationObject = (DTE2)application;
    		_addInInstance = (AddIn)addInInst;
    
    		//SET THE MEMBER VARIABLES
    		//_debuggerEvents = _applicationObject.Events.DebuggerEvents;
    		//_debuggerEvents.OnEnterBreakMode += new _dispDebuggerEvents_OnEnterBreakModeEventHandler(BreakHandler);
    		//var watchWindow = _applicationObject.Windows.Item(EnvDTE.Constants.vsWindowKindWatch);
    		_objCommandEvents = _applicationObject.Events.CommandEvents;
    		_objCommandEvents.BeforeExecute += new _dispCommandEvents_BeforeExecuteEventHandler(BeforeExecute);
    	  
    		if(connectMode == ext_ConnectMode.ext_cm_UISetup)
    		{
    			object []contextGUIDS = new object[] { };
    			Commands2 commands = (Commands2)_applicationObject.Commands;
    			string toolsMenuName = "Tools";
    
    			Microsoft.VisualStudio.CommandBars.CommandBar menuBarCommandBar = ((Microsoft.VisualStudio.CommandBars.CommandBars)_applicationObject.CommandBars)["MenuBar"];
    ar:
    			CommandBarControl toolsControl = menuBarCommandBar.Controls[toolsMenuName];
    			CommandBarPopup toolsPopup = (CommandBarPopup)toolsControl;
    			try
    			{
    				Command command = commands.AddNamedCommand2(_addInInstance, "AddinMultiLineWatch", "AddinMultiLineWatch", "Executes the command for AddinMultiLineWatch", true, 59, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported+(int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
    
    				if((command != null) && (toolsPopup != null))
    				{
    					command.AddControl(toolsPopup.CommandBar, 1);
    				}
    			}
    			catch(System.ArgumentException)
    			{
    			}
    		}
    	}
    
    	//ADD THIS METHOD TO INTERCEPT THE DEBUG.ADDWATCH COMMAND
    	public void BeforeExecute(string Guid, int ID, object CustomIn, object CustomOut, ref bool CancelDefault)
    	{
    		EnvDTE.Command objCommand = default(EnvDTE.Command);
    		try
    		{
    			objCommand = _applicationObject.Commands.Item(Guid, ID);
    		}
    		catch (Exception ex)
    		{
    		}
    
    		if ((objCommand != null))
    		{
    			if (objCommand.Name == "Debug.AddWatch")
    			{
    				//if (_isRecursive) return;
    				//_isRecursive = true;
    				TextSelection selection = (TextSelection)_applicationObject.ActiveDocument.Selection;
    				//TO DO make selection goto next semi-colon to do it by Line Terminator...
    				var selText = selection.Text;                    
    				if (string.IsNullOrEmpty(selText)) return;
                    //UNFORTUNATELY THIS CALL IS RECURSIVE, I'LL LEAVE IT TO THE READER AS AN EXERCISE TO SOLVE..
    				_applicationObject.ExecuteCommand("Debug.AddWatch", selText.Replace(Environment.NewLine, string.Empty));
    			}
    		}
    	}
