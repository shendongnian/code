	[Activity(Label = "FilePathFromContentURI", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);
			Button button = FindViewById<Button>(Resource.Id.myButton);
			button.Click += delegate { 
				Intent intent = new Intent();
				intent.SetType("image/*");
				intent.SetAction(Intent.ActionGetContent);
				StartActivityForResult(Intent.CreateChooser(intent, "Select Image"), 1);
			};
		}
		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			ICursor cursor = null;
			try
			{
				// assuming image
				var docID = DocumentsContract.GetDocumentId(data.Data);
				var id = docID.Split(':')[1];
				var whereSelect = MediaStore.Images.ImageColumns.Id + "=?";
				var projections = new string[] { MediaStore.Images.ImageColumns.Data };
				// Try internal storage first
				cursor = ContentResolver.Query(MediaStore.Images.Media.InternalContentUri, projections, whereSelect, new string[] { id }, null);
				if (cursor.Count == 0)
				{
					// not found on internal storage, try external storage
					cursor = ContentResolver.Query(MediaStore.Images.Media.ExternalContentUri, projections, whereSelect, new string[] { id }, null);
				}
				var colData = cursor.GetColumnIndexOrThrow(MediaStore.Images.ImageColumns.Data);
				cursor.MoveToFirst();
				var fullPathToImage = cursor.GetString(colData);
				Log.Info("MediaPath", fullPathToImage);
			}
			catch (Error err)
			{
				Log.Error("MediaPath", err.Message);
			}
			finally
			{
				cursor?.Close();
				cursor?.Dispose();
			}
		}
	}
