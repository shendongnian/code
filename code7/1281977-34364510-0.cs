            public const string productName = "myMillionDollarAddin";
            private void RegisterTaskPane()
            {
                var tskControl = new TaskPaneControl();
                CustomTaskPane taskPane = this.CustomTaskPanes.Add(tskControl, productName);
                taskPane.Visible = true;
            }
    
            public void ShowHideTaskPane()
            {
                var taskPane = this.CustomTaskPanes.FirstOrDefault(ctp => ctp.Title == productName);
                if (taskPane == null)
                {
                    RegisterTaskPane();
                }
                else
                {
                    var visibility = taskPane.Visible;
                    taskPane.Visible = !visibility;
                }
            }
