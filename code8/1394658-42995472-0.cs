		void CallService ()
		{
			Device.BeginInvokeOnMainThread (() => UserDialogs.Instance.ShowLoading ("Loading ...", MaskType.Black));
			Task.Run (async () => {
				await DependencyService.Get<IJsonMethods> ().Load ("SERVICE_URL");
			}).ContinueWith (result => Device.BeginInvokeOnMainThread (() => {
				UserDialogs.Instance.HideLoading ();
				}
			})
			);
		}
