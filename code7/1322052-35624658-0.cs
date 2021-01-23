    using System.Threading.Tasks;
	async void Print() // Use async
	{
		PrintDialog pd = new PrintDialog();
		scrollView.ScrollToHome();
		await Task.Delay(TimeSpan.FromSeconds(1.0)); // Wait 1 second scrollView being properly rendered.
		pd.PrintVisual(scrollView, "print this off");
	}
