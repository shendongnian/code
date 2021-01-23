    public class ControlHelper
    {
        public virtual String GetControlName(Control control)
        {
            return control.Name.ToString();
        }
    
        // it is not possible to do the logic on a generic control, so force derived classes to provide the logic
        public abstract void DoSomeFancyStuffWithControl(Control control);
    
        // other common functions may come here
    }
    
    public class LabelHelper : ControlHelper
    {
        // you may override virtual methods from ControlHelper. For GetControlName, it should not be the case
        public override DoSomeFancyStuffWithControl(Control control)
        {
            var button = control as Label;
            // ...
        }
    
        // does not have to be virtual, but allow further inheritance
        public virtual String GetText(Label l)
        {
            return l.Text;
        }
    
        // other label specific methods come here
    }
    
    public class ButtonHelper : ControlHelper
    {
        public override DoSomeFancyStuffWithControl(Control control)
        {
            var button = control as Button;
            // ...
        }
    
        public virtual bool GetEnabled(Button b)
        {
            return b.Enabled;
        }
    
        // other button specific functions may come here
     }
