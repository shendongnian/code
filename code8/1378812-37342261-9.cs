    public abstract class EnvironmentControl
    {
        public static EnvironmentControl Current
        {
            get
            {
                return _current;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                _current = value;
            }
        }
        public abstract void Exit(int value);
        public static void ResetToDefault()
        {
            _current = DefaultEnvironmentControl.Instance;
        }
        static EnvironmentControl _current = DefaultEnvironmentControl.Instance;
    }
    public class DefaultEnvironmentControl : EnvironmentControl
    {
        public override void Exit(int value)
        {
            Environment.Exit(value);
        }
        public static DefaultEnvironmentControl Instance => _instance.Value;
        static readonly Lazy<DefaultEnvironmentControl> _instance = new Lazy<DefaultEnvironmentControl>(() => new DefaultEnvironmentControl());
    }
