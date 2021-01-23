    public override void OnBackPressed()
    {
        Finish();
        Android.OS.Process.KillProcess (Android.OS.Process.MyPid ());
	}
