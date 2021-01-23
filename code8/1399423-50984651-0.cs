     private ActionBar ab;
     protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                ab = this.ActionBar;
                ab.Hide();
            }
             catch (Exception ex)
            {
         
            }
        }
