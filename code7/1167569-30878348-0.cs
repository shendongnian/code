    protected override void OnResume()
    {
        base.OnResume();
        
        CheckBox whatever = FindViewById<CheckBox>(Resource.Id.checkBox1);
        if (whatever != null) //Verify the state of your whatever object to avoid exception
        {
            whatever.Click += (s, e) =>
            {
                if (!whatever.Checked)
                {
                    //do stuff
                }
            };
        }
    }
