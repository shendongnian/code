    public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst, ref System.Array custom) {
       applicationObject = application;
       addInInstance = addInInst;
    
       if(connectMode != Extensibility.ext_ConnectMode.ext_cm_Startup)
       {
          OnStartupComplete(ref custom);
       }
    
    }
    
    public void OnDisconnection(Extensibility.ext_DisconnectMode disconnectMode, ref System.Array custom) {
       if(disconnectMode != Extensibility.ext_DisconnectMode.ext_dm_HostShutdown)
       {
          OnBeginShutdown(ref custom);
       }
       applicationObject = null;
    }
    
    
    public void OnAddInsUpdate(ref System.Array custom)
    {
    }
    
    public void OnStartupComplete(ref System.Array custom)
    {
       CommandBars oCommandBars;
       CommandBar oStandardBar;
    
       try
       {
       oCommandBars = (CommandBars)applicationObject.GetType().InvokeMember("CommandBars", BindingFlags.GetProperty , null, applicationObject ,null);
       }
       catch(Exception)
       {
       // Outlook has the CommandBars collection on the Explorer object.
       object oActiveExplorer;
       oActiveExplorer= applicationObject.GetType().InvokeMember("ActiveExplorer",BindingFlags.GetProperty,null,applicationObject,null);
       oCommandBars= (CommandBars)oActiveExplorer.GetType().InvokeMember("CommandBars",BindingFlags.GetProperty,null,oActiveExplorer,null);
       }
    
       // Set up a custom button on the "Standard" commandbar.
       try
       {
       oStandardBar = oCommandBars["Standard"];        
       }
       catch(Exception)
       {
       // Access names its main toolbar Database.
       oStandardBar = oCommandBars["Database"];      
       }
    
       // In case the button was not deleted, use the exiting one.
       try
       {
       MyButton = (CommandBarButton)oStandardBar.Controls["My Custom Button"];
       }
       catch(Exception)
       {
          object omissing = System.Reflection.Missing.Value ;
          MyButton = (CommandBarButton) oStandardBar.Controls.Add(1, omissing , omissing , omissing , omissing);
          MyButton.Caption = "My Custom Button";
          MyButton.Style = MsoButtonStyle.msoButtonCaption;
       }
    
       // The following items are optional, but recommended. 
       //The Tag property lets you quickly find the control 
       //and helps MSO keep track of it when more than
       //one application window is visible. The property is required
       //by some Office applications and should be provided.
       MyButton.Tag = "My Custom Button";
    
       // The OnAction property is optional but recommended. 
       //It should be set to the ProgID of the add-in, so that if
       //the add-in is not loaded when a user presses the button,
       //MSO loads the add-in automatically and then raises
       //the Click event for the add-in to handle. 
       MyButton.OnAction = "!<MyCOMAddin.Connect>";
    
       MyButton.Visible = true;
       MyButton.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(this.MyButton_Click);
    
    
       object oName = applicationObject.GetType().InvokeMember("Name",BindingFlags.GetProperty,null,applicationObject,null);
    
       // Display a simple message to show which application you started in.
       System.Windows.Forms.MessageBox.Show("This Addin is loaded by " + oName.ToString()   , "MyCOMAddin");
       oStandardBar = null;
       oCommandBars = null;
    }
    
    public void OnBeginShutdown(ref System.Array custom)
    {
       object omissing = System.Reflection.Missing.Value ;
       System.Windows.Forms.MessageBox.Show("MyCOMAddin Add-in is unloading.");
       MyButton.Delete(omissing);
       MyButton = null;
    }
    
    private void MyButton_Click(CommandBarButton cmdBarbutton,ref bool cancel) {
       System.Windows.Forms.MessageBox.Show("MyButton was Clicked","MyCOMAddin"); }
