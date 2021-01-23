    protected override void OnCreate(Bundle bundle)
    {
        // ...
        mBtnSignIn = FindViewById<Button>(Resource.Id.buttonLogIn);
        mBtnSignIn.Click += mBtnSignIn_Click;
        // ...
    }
