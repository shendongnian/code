    public class MainActivity : Activity, View.IOnTouchListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
    
            EditText edt = FindViewById<EditText>(Resource.Id.myEditText);
            edt.SetOnTouchListener(this);
    
            Button button = FindViewById<Button>(Resource.Id.myButton);
            button.Click += delegate { edt.Text = edt.Text.Insert(edt.SelectionStart, "*"); };
        }
    
        public bool OnTouch(View v, MotionEvent e)
        {
            // Pass the event to the edit text to have the blinking cursor.
            v.OnTouchEvent(e);
            // Hide the input.
            var imm = ((InputMethodManager)v.Context.GetSystemService(Context.InputMethodService));
            imm?.HideSoftInputFromWindow(v.WindowToken, HideSoftInputFlags.None);
            return true;
        }
    }
