	async public void PushPage()
	{
        // Do some Android specific things... and then push a new Forms' Page
		await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new PushPageFromNative.MyPage());
	}
