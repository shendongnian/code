    using Ozeki.Media.IPCamera;
    using Ozeki.Media.MediaHandlers.Video;
    using Ozeki.Media.Video.Controls;
    using Ozeki.Media.MediaHandlers;
    public partial class Snapshot {
        private SnapshotHandler _snapshotHandler;
		
		private void CreateSnapShot(string path) {
					var date = DateTime.Now.Year + "y-" + DateTime.Now.Month + "m-" + DateTime.Now.Day + "d-" +
							   DateTime.Now.Hour + "h-" + DateTime.Now.Minute + "m-" + DateTime.Now.Second + "s";
					string currentpath;
					if (String.IsNullOrEmpty(path))
						currentpath = date + ".jpg";
					else
						currentpath = path + "\\" + date + ".jpg";
					var snapShotImage = _snapshotHandler.TakeSnapshot().ToImage();
					snapShotImage.Save(currentpath, System.Drawing.Imaging.ImageFormat.Jpeg);
		}
