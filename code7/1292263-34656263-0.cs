    private void ExecuteCommand(CommandTargets parameter)
        {
            switch (parameter)
            {
                case CommandTargets.EditProperties:
                    PropertiesView PropertiesWindow = new PropertiesView();
                    PropertiesWindow.DataContext=this;  //<----------- add this line 
                    PropertiesWindow.Show();
                    break;
            }
        }
