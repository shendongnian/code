	public static IObservable<ObservableCollection<WebElementWrapper>>
		GetAllElementsAsObservable(this IWebDriver wd)
	{
		return Observable.Create<ObservableCollection<WebElementWrapper>>(observer =>
			Observable
				.Start(() =>
					wd
						.FindElements(By.CssSelector("*"))
						.ToWebElementObservableCollection())
				.Subscribe(observer));
	}
