        private void OnSelectViewCommand(CommandParameter obj)
        {
            switch (obj.Command)
            {
                case  Command.Exit:
                    Application.Current.Shutdown();
                    break;
                case Command.LogOn :
                    // we know that Obj is going to be and instance of User
                    User usr = (User)obj.Obj;
                    // SQL to Validate User 
                    if (usr.LogOn)
                        Current_ViewModel = this.GetViewModel(obj.Link_1);
                    else
                        Current_ViewModel = this.GetViewModel(obj.Link_2);
                    break;
                default:
                    Current_ViewModel = this.GetViewModel(obj.Link_1);
                    break;
            }
        }
