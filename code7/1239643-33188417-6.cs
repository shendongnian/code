    public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken) {
			ParseObject obj = ParseObject.Create ("_Installation");
			string dt = deviceToken.ToString ().Replace ("<", "").Replace (">", "").Replace (" ", "");
			obj["deviceToken"] = dt;
			obj.SaveAsync ().ContinueWith (t => {
				if (t.IsFaulted) {
					using (IEnumerator<System.Exception> enumerator = t.Exception.InnerExceptions.GetEnumerator()) {
						if (enumerator.MoveNext()) {
							ParseException error = (ParseException) enumerator.Current;
							Console.WriteLine ("ERROR!!!: " + error.Message);
						}
					}
				} else {
					Console.WriteLine("Saved/Retrieved Installation");
					var data = NSUserDefaults.StandardUserDefaults;
					data.SetString ("currentInstallation", obj.ObjectId);
					Console.WriteLine("Installation ID = " + obj.ObjectId);
				}
			});
		}
