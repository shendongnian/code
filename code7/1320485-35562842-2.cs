    class DesignerPropertiesWrapper : IDesignerProperties
    {
        public bool IsInDesigner 
        {
            get { return DesignerProperties.IsInDesigner; } 
        }
        
        public void DoSomething(string arg)
        {
            DesignerProperties.DoSomething(arg);
        }
        // forward other properties and methods to the static class
    }
