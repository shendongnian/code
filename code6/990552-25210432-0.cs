        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.Main);
            this.FindViewById<Button>(Resource.Id.ForwardButton).Click += this.Forward;
        }
        public void Forward(object sender, EventArgs e)
        {
            this.StartActivity (typeof(Main2));
        }
