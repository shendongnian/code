    public class UI : CrestronControlSystem {
        public object myPanel;
    
        public void DefineUI(ushort id, string type, string location) {
            Type panelType = Type.GetType(type);
            this.myPanel = Activator.CreateInstance(panelType);
        }
    }
