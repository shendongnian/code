        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            timerViewer = FindViewById<TextView>(Resource.Id.textView1);
            RunUpdateLoop();
        }
        private async void RunUpdateLoop()
        {
            int count = 1;
            while (true)
            {
                await Task.Delay(1000);
                timerViewer .Text = string.Format("{0} ticks!", count++);
            }
        }
