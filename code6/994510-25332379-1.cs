    public class MyControl: Control
    {
        public DataTemplateManager DataTemplateManager {get; private set;}
        public MyControl()
        {
            this.DataTemplateManager = new DataTemplateManager();
        }
    }
