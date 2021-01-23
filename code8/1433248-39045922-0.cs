	var input = Assets.Open(packageName);
	var packageInstaller = PackageManager.PackageInstaller;
	var sessionParams = new PackageInstaller.SessionParams(PackageInstallMode.FullInstall);
	sessionParams.SetAppPackageName(packageName);
	int sessionId = packageInstaller.CreateSession(sessionParams);
	var session = packageInstaller.OpenSession(sessionId);
	using (var output = session.OpenWrite(packageName, 0, -1))
	{
		input.CopyTo(output);
		session.Fsync(output);
		foreach (var name in session.GetNames())
			Log.Debug("Installer", name);
		output.Close();
		output.Dispose();
		input.Close();
		input.Dispose();
		GC.Collect();
	}
	var pendingIntent = PendingIntent.GetBroadcast(BaseContext, sessionId, new Intent(Intent.ActionInstallPackage), 0);
	session.Commit(pendingIntent.IntentSender);
