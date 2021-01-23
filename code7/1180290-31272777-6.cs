    [Activity(Label = "App14", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Keyboard _keyBoard;
        private EditText _targetView;
        private KeyboardView _keyboardView;
    
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
    
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
    
            _keyBoard = new Keyboard(this, Resource.Xml.keyboard);
            _keyboardView = FindViewById<KeyboardView>(Resource.Id.keyboard_view);
            _keyboardView.Keyboard = _keyBoard;
            _keyboardView.OnKeyboardActionListener = new MyKeyboardListener(this);
            _targetView = FindViewById<EditText>(Resource.Id.target);
            _targetView.Touch += (sender, args) => {
                var bottomUp = AnimationUtils.LoadAnimation(this, Resource.Animation.slide_up);
                _keyboardView.StartAnimation(bottomUp);
                _keyboardView.Visibility = ViewStates.Visible;
                args.Handled = true;
            };
        }
    }
