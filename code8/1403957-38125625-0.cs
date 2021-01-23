    abstract class ClassPlugin
    {
        public abstract void Action();
    }
    
    class ClassStartWF: ClassPlugin
    {
        public ClassStartWF(eGuiType _guyType)
        {
            GuiType = _guyType;
        }
    
        public override void Action()
        {
            MessageBox.Show(GetType().Name);
        }
    }
