    [Activity (Label = "SimplyActivity", Theme="@style/MyTheme")]           
            public class SimplyActivity : ActionBarActivity
            {
                private Toolbar toolbar;
    // ...
    // OnCreate method
    this.toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
    SetSupportActionBar (this.toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled (true);
                SupportActionBar.SetHomeButtonEnabled (true);
    //dont forget this
                this.toolbar.SyncState();
    this.toolbar += ClickedMenu;
    
    public override bool OnOptionsItemSelected (IMenuItem item)
            {
                this.OnOptionsItemSelected(item);
                return base.OnOptionsItemSelected (item);
            }
    
     public void ClickedMenu(object sender,SupportToolbar.MenuItemClickEventArgs e)
            {
                switch (e.Item.ItemId)
                {     //your TitleFormatted ID
                    case Resource.Id.action_edit:
                        //do stuff here
                    this.OnBackPressed ();
                        break;
                }
            }
     protected override void OnPostCreate(Bundle savedInstanceState)
            {
                base.OnPostCreate(savedInstanceState);
                _Toogle.SyncState();     
            }
