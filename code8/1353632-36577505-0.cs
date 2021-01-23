     [Activity (Label = "VideoActivity")]			
     public class VideoActivity : Activity
     {
            // Create your application here
            VideoView videoView;
            protected override void OnCreate (Bundle bundle)
            {
            base.OnCreate (bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.VideoActivity);
            videoView = FindViewById<VideoView> (Resource.Id.SampleVideoView);
            videoView.SetMediaController(new MediaController(this));
            videoView.SetVideoPath ($"android.resource://{PackageName}/{Resource.Raw.bunny}");
            videoView.RequestFocus ();
            videoView.Start ();
        }
    }
