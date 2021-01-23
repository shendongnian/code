    public static class Program
    {
        public static void Main()
        {
            var largeClass = new LargeClass() { Blah = 423 };
            var inputBox = new InputBox<double>(
                () => largeClass.Blah, 
                (a) => largeClass.Blah = a
                );
        }
    }
    public class LargeClass
    {
        public double Blah { get; set; }
    }
    public class InputBox<T> : TextBox
    {
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            try
            {
                _setter((T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(Text));
            }
            catch (Exception e1)
            {
                //Utils.offensiveMessage("Invalid format! This field accepts only " + value.GetType().Name + "!");
                Focus();
                Text = _getter().ToString();
            }
        }
        private Func<T> _getter;
        private Action<T> _setter;
        public InputBox(Func<T> getter, Action<T> setter) : base()
        {
            _getter = getter;
            _setter = setter;
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            Text = _getter().ToString();
        }
    }
