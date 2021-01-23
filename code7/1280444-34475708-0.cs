    public interface IControlWithLabel
    {
        Label Label
        {
            get;
        }
        Control Control
        {
            get;
        }
    }
    /// <summary>
    /// Here we use covariance
    /// </summary>
    public interface IControlWithLabel<out TControl> : IControlWithLabel where TControl : Control, new()
    {
        new TControl Control
        {
            get;
        }
    }
    /// <summary>
    /// Common base, never instantiated
    /// </summary>
    public abstract class ControlWithLabel : IControlWithLabel
    {
        protected Control _control;
        public ControlWithLabel()
        {
            this.Label = new Label();
        }
        public Label Label
        {
            get;
            private set;
        }
        /// <summary>
        /// This property cannot be marked as 'abstract', because we want to change the return type in descendants
        /// </summary>
        public virtual Control Control
        {
            get
            {
                return _control;
            }
        }
    }
    public class ControlWithLabel<TControl> : ControlWithLabel, IControlWithLabel<TControl> where TControl : Control, new()
    {
        public ControlWithLabel() : base()
        {
            this.Control = new TControl();
        }
        /// <summary>
        /// We cannot use 'override', since we want to return TControl instead of Control
        /// </summary>
        public new TControl Control
        {
            get
            {
                return _control as TControl;
                // This will return null if _control is not TControl.
                // This can happen, when we make an explicit cast for example TextBoxWithLabel to ComboBoxWithLabel, which requires an explicit conversion operator implementation.
                // In such case there can be still used general ControlWithLabel.Control, which always will be "not null" - for example ((ControlWithLabel)someObject).Control
                // (the general ControlWithLabel.Control will always be "not null", because the base class ControlWithLabel is marked as abstract and current class ControlWithLabel<TControl> creates the control in the constructor).
            }
            private set
            {
                _control = value;
            }
        }
    }
    public class TextBoxWithLabel : ControlWithLabel<TextBox>
    {
        public void SpecialMethodForTextBox()
        {
            // Special code ...
        }
    }
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private void _buttonTest_Click(object sender, EventArgs e)
        {
            TextBoxWithLabel textBoxWithLabel = new TextBoxWithLabel();
            // This works
            if (textBoxWithLabel is ControlWithLabel<TextBox>)
            {
                // We can use the general ControlWithLabel.Control
                if (((ControlWithLabel)textBoxWithLabel).Control != null)
                    MessageBox.Show("textBoxWithLabel is ControlWithLabel<TextBox>");
            }
            // This is not working, since classes cannot be covariant
            if (textBoxWithLabel is ControlWithLabel<Control>)
            {
                // We can use the general ControlWithLabel.Control
                if (((ControlWithLabel)textBoxWithLabel).Control != null)
                    MessageBox.Show("textBoxWithLabel is ControlWithLabel<Control>");
            }
            // This works!
            if (textBoxWithLabel is ControlWithLabel)
            {
                // We can use the general ControlWithLabel.Control
                if (((ControlWithLabel)textBoxWithLabel).Control != null)
                    MessageBox.Show("textBoxWithLabel is ControlWithLabel");
            }
            // This works
            if (textBoxWithLabel is IControlWithLabel<TextBox>)
            {
                // We can use the general INTERFACE property IControlWithLabel.Control
                if (((IControlWithLabel)textBoxWithLabel).Control != null)
                    MessageBox.Show("textBoxWithLabel is IControlWithLabel<TextBox>");
            }
            // This works thanks to COVARIANCE
            if (textBoxWithLabel is IControlWithLabel<Control>)
            {
                // We can use the general INTERFACE property IControlWithLabel.Control
                if (((IControlWithLabel)textBoxWithLabel).Control != null)
                    MessageBox.Show("textBoxWithLabel is IControlWithLabel<Control>");
            }
            // This works!
            if (textBoxWithLabel is IControlWithLabel)
            {
                // We can use the general INTERFACE property IControlWithLabel.Control
                if (((IControlWithLabel)textBoxWithLabel).Control != null)
                    MessageBox.Show("textBoxWithLabel is IControlWithLabel");
            }
        }
    }
