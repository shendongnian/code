    public class ParameterAddress : Parameter
    {
        ControllerList controllers;
        #region constructors
        public ParameterAddress (ControllerList controllers, String address)
        {
            this.controllers=controllers;
            Name="Address";
            Value=address;
            EditAddrCmd=new RelayCommand(ex => EditAddrCmdExec(), cex => EditAddrCmdCanExec());
        }
        // ..
        #endregion // constructors
        #region commands
        public ICommand EditAddrCmd { get; internal set; }
        private void EditAddrCmdExec ()
        {
            // open dialog to edit address and save to <Value>
        }
        private bool EditAddrCmdCanExec ()
        {
            return true;
        }
        #endregion // comannds
        public override bool isValid ()
        {
            return true;
        }
    }
