    VersionControlServer versionControlServer = (VersionControlServer)tfs.GetService(typeof(VersionControlServer)); 
    Assembly controlsAssembly = Assembly.GetAssembly(typeof(Microsoft.TeamFoundation.VersionControl.Controls.ControlAddItemsExclude)); 
    Type vcChooseItemDialogType = controlsAssembly.GetType("Microsoft.TeamFoundation.VersionControl.Controls.DialogChooseItem"); 
    ConstructorInfo ci = vcChooseItemDialogType.GetConstructor( 
                       BindingFlags.Instance | BindingFlags.NonPublic, 
                       null, 
                       new Type[] { typeof(VersionControlServer) }, 
                       null); 
    _chooseItemDialog = (Form)ci.Invoke(new object[] { versionControlServer }); 
    _chooseItemDialog.ShowDialog(); 
     this.DialogResult = _chooseItemDialog.DialogResult; 
