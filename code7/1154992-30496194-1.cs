	public class MainActivity : Activity
	{
		public const string BITMAP_URL = @"http://www.openjpeg.org/samples/Bretagne2.bmp";
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				System.Threading.Tasks.Task.Run( () => {
					RunOnUiThread( () => Toast.MakeText(this, "Downloading file", ToastLength.Long).Show());
					string downloadFile = DownloadSourceImage(BITMAP_URL);
					RunOnUiThread( () => Toast.MakeText(this, "Rescaling image: " + downloadFile, ToastLength.Long).Show());
					string convertedFile = ResizeImage(downloadFile);
					var bmpFileSize = (new FileInfo(downloadFile)).Length;
					var pngFileSize = (new FileInfo(convertedFile)).Length;
					RunOnUiThread( () => Toast.MakeText(this, "BMP is " + bmpFileSize + "B. PNG is " + pngFileSize + "B.", ToastLength.Long).Show());
				});
			};
		}
		public string DownloadSourceImage(string url)
		{
			System.Net.WebClient client = new System.Net.WebClient ();
			string fileName = url.Split ('/').LastOrDefault ();
			string downloadedFilePath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, fileName);
			if (File.Exists (downloadedFilePath) == false) {
				client.DownloadFile (url, downloadedFilePath);
			}
			return downloadedFilePath;
		}
		public string ResizeImage(string sourceFilePath)
		{
			Android.Graphics.Bitmap bmp = Android.Graphics.BitmapFactory.DecodeFile (sourceFilePath);
			string newPath = sourceFilePath.Replace(".bmp", ".png");
			using (var fs = new FileStream (newPath, FileMode.OpenOrCreate)) {
				bmp.Compress (Android.Graphics.Bitmap.CompressFormat.Png, 100, fs);
			}
			return newPath;
		}
	}
