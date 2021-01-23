        private class ButtonClickListener : Java.Lang.Object, Android.Views.View.IOnClickListener
        {
            private Activity activity;
            private ObservableCollection<UserButtonLabel> buttonCollection = new ObservableCollection<UserButtonLabel>();
            private CustomButtonAdapter listAdapter;
            public ButtonClickListener(Activity activity)
            {
                this.activity = activity;
            }
            public async void OnClick(Android.Views.View v)
            {
                ListView ButtonListview = activity.FindViewById<ListView>(Resource.Id.ButtonListview);
                string name = (string)v.Tag;
                string text = string.Format("{0} Button Click.", name);
                Toast.MakeText(this.activity, text, ToastLength.Short).Show();
                    Task<string> asyncClock = Vm.ClockCommand();
                    string results = await asyncClock;
                    var dialog = ChangeDateTimeDialogFragment.NewInstance();
                    dialog.Show(this.activity.FragmentManager, "dialog");
                    Vm.ShowCurrentUser();
                    buttonCollection = await Vm.ShowButtons();
                    if (buttonCollection.Count > 0)
                    {
                        listAdapter = new CustomButtonAdapter(activity, buttonCollection);
                        ButtonListview.Adapter = listAdapter;
                        ((BaseAdapter)this.listAdapter).NotifyDataSetChanged();
                    }
                }
          
        }
        private static UserTimeTrackingViewModel Vm
        {
            get
            {
                return App.Locator.UserTimeTracker;
            }
        }
    }
