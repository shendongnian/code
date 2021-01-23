        private void OnSelectViewCommand(CommandParameter obj)
        {
            switch (obj.Command)
            {
                case  Command.Exit:
                    Application.Current.Shutdown();
                    break;
                case Command.LogOn :
                    // SQL to Validate User 
                    // OK
                    Current_ViewModel = this.GetViewModel(obj.Link_1);
                    // Not OK
                    //Current_ViewModel = this.GetViewModel(obj.Link_2);
                    break;
                default:
                    Current_ViewModel = this.GetViewModel(obj.Link_1);
                    break;
            }
        }
