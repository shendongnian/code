	[Activity(Label = "DroidVideo", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, MediaPlayer.IOnInfoListener, MediaPlayer.IOnErrorListener
	{
		public bool OnError(MediaPlayer mp, [GeneratedEnum] MediaError what, int extra)
		{
			Log.Debug("Media", what.ToString());
			return true;
		}
		public bool OnInfo(MediaPlayer mp, [GeneratedEnum] MediaInfo what, int extra)
		{
			Log.Info("Media", what.ToString());
			return true;
		}
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);
			Button button = FindViewById<Button>(Resource.Id.myButton);
			button.Click += delegate { 
				VideoView video = FindViewById<VideoView>(Resource.Id.myVideo);
				video.SetOnInfoListener(this);
				var videoUri = Android.Net.Uri.Parse("android.resource://" + Path.Combine(PackageName, "raw", Resource.Raw.pool.ToString()));
				video.SetVideoURI(videoUri);
				video.Start();
			};
		}
	}
