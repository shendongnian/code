    public override void OnBackPressed()
    {
        var intent = new Intent(this, typeof(MainActivity));
        StartActivity(intent);
    
        //base.OnBackPressed(); -> DO NOT CALL THIS LINE OR WILL NAVIGATE BACK
    }
