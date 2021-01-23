    public class CommandService : ICommandService
    {
        private WorkflowDesigner WorkflowDesigner;
        public CommandService(WorkflowDesigner designer) { this.WorkflowDesigner = designer; }
        public bool CanExecuteCommand(int commandId)
        {
            return true;
            
        }
        public event EventHandler BreakpointsChanged;
        public event EventHandler ShowPropertiesRequested;
        public void ExecuteCommand(int commandId, Dictionary<string, object> parameters)
        {
            switch (commandId)
            {
                case CommandValues.InsertBreakpoint:
                    WorkflowDesigner.Context.Services.GetService<IDesignerDebugView>().UpdateBreakpoint((SourceLocation)parameters["SourceLocation"], (BreakpointTypes)parameters["BreakpointTypes"] | BreakpointTypes.Enabled);
                    if (BreakpointsChanged != null)
                        BreakpointsChanged(this, new EventArgs());
                    break;
                case CommandValues.DeleteBreakpoint:
                    WorkflowDesigner.Context.Services.GetService<IDesignerDebugView>().UpdateBreakpoint((SourceLocation)parameters["SourceLocation"], BreakpointTypes.None);
                    if (BreakpointsChanged != null)
                        BreakpointsChanged(this, new EventArgs());
                    break;
                case CommandValues.EnableBreakpoint:
                    WorkflowDesigner.Context.Services.GetService<IDesignerDebugView>().UpdateBreakpoint((SourceLocation)parameters["SourceLocation"], BreakpointTypes.Enabled | BreakpointTypes.Bounded);
                    if (BreakpointsChanged != null)
                        BreakpointsChanged(this, new EventArgs());
                    break;
                case CommandValues.DisableBreakpoint:
                    WorkflowDesigner.Context.Services.GetService<IDesignerDebugView>().UpdateBreakpoint((SourceLocation)parameters["SourceLocation"], BreakpointTypes.Bounded);
                    if (BreakpointsChanged != null)
                        BreakpointsChanged(this, new EventArgs());
                    break;
                case CommandValues.ShowProperties:
                    if (ShowPropertiesRequested != null)
                        ShowPropertiesRequested(this, new EventArgs());
                    break;
            }
        }
        public bool IsCommandSupported(int commandId)
        {
            switch (commandId)
            {
                case CommandValues.ShowProperties:
                case CommandValues.InsertBreakpoint:
                case CommandValues.DeleteBreakpoint:
                case CommandValues.EnableBreakpoint:
                case CommandValues.DisableBreakpoint:
                    return true;
                default:
                    return false;
            }
        }
    }
