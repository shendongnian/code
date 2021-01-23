    protected override void OnRegistered (Context context, string registrationId)
		{
			Console.WriteLine ("Device Id:" + registrationId);
			var preferences = GetSharedPreferences("AppData", FileCreationMode.Private);
			var deviceId = preferences.GetString("DeviceId","");
			if (string.IsNullOrEmpty (deviceId)) {
				var editor = preferences.Edit ();
				editor.PutString ("DeviceId", registrationId);
				editor.Commit ();
			}
		}
