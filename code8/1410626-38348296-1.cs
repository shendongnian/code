    public  class MyActivity : Activity
        {
    
            private const int DRTC = 0;
            private const int DRR = 1;
               protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
    
                // Create your application here
                SetContentView(Resource.Layout.activity_my);
    
    
            }
      public override bool OnCreateOptionsMenu(IMenu menu)
            {
                bool result = base.OnCreateOptionsMenu(menu);
                menu.Add(0, DRTC, 0, "Modify TC");
                menu.Add(0, DRR, 0, "Restart DR");
    
                return result;
            }
     public override bool OnOptionsItemSelected(IMenuItem item)
            {
                switch (item.ItemId)
                {
                case  DRTC: 
            //Code
             Break;
                 case  DRR:
            //Code
                 Break;
                 bool result = base.OnOptionsItemSelected(item);
            return result;
    }
    }
    
