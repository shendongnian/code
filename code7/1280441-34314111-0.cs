    public class TextBoxWithLabel : ControlWithLabel<TextBox>
    {
        public void SpecialMethodForTextBox()
        {
            // Special code ...
        }
    }
    public class ControlWithLabel<TControl> 
        IControlWithLabel, 
        IControlWithLabel<TControl> where TControl : Control, new()
    {
        public ControlWithLabel()
        {
            Control = new TControl();
            Label = new Label();
        }
        public Label Label { get; private set; }
        public TControl Control { get; private set; }
    }
    public interface IControlWithLabel<out TControl> where TControl : Control
    {
        Label Label { get; }
        TControl Control { get; }
    }
    public interface IControlWithLabel
    {
        Label Label { get; }
    }
