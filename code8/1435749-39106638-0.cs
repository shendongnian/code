    [Activity(Label = "Employee Management", Theme = "@android:style/Theme.Material")]
    public class EmpMgmtActivity : Activity
    {
        ListView empListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EmpMgmtLayout);
            
            empListView = FindViewById<ListView>(Resource.Id.EmpMgmtList);
            GenerateEmpList(EmployeeStorage.employeeList);
            empListView.ItemClick += EmpListView_ItemClick;
        }
        private void EmpListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var menu = new PopupMenu(this, empListView.GetChildAt(e.Position));
            menu.Inflate(Resource.Layout.popup_menu);
            menu.MenuItemClick += (s, a) =>
            {
                switch (a.Item.ItemId)
                {
                    case Resource.Id.pop_button1:
                        // update stuff
                        break;
                    case Resource.Id.pop_button2:
                        // delete stuff
                        break;
                }
            };
            menu.Show();
        }
