    Button button = FindViewById (Resource.Id.myButton);
    button.Touch += (object sender, View.TouchEventArgs e) =>
    {
    if (e.Event.Action == MotionEventActions.Up)
    {
    Toast.MakeText(this, "Key Up", ToastLength.Short).Show();
    }
            if(e.Event.Action == MotionEventActions.Down)
            {
                Toast.MakeText(this, "Key Down", ToastLength.Short).Show();
            }
        };
