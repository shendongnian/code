    namespace CSharpWPF
    {
        /// <summary>
        /// Interaction logic for StateButton.xaml
        /// </summary>
        public partial class StateButton : Button
        {
            public StateButton()
            {
                InitializeComponent();
                Click += (s, e) => ToggleState();
            }
            void ToggleState()
            {
                int? curState = State;
                if (curState == null)
                    curState = 0;
                else
                    curState++;
                if (curState > 2)
                    curState = null;
                State = curState;
            }
            public int? State
            {
                get { return (int?)GetValue(StateProperty); }
                set { SetValue(StateProperty, value); }
            }
            // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty StateProperty =
                DependencyProperty.Register("State", typeof(int?), typeof(StateButton), new PropertyMetadata(null), OnValidateState);
            private static bool OnValidateState(object value)
            {
                if (value == null)
                    return true;
                int parseResult = 0;
                if (int.TryParse(Convert.ToString(value), out parseResult))
                {
                    if (parseResult >= 0 && parseResult < 3)
                        return true;
                }
                return false;
            }
        }
    }
