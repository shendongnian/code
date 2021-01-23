	private static BaseResponse GetData(HomeIndexGetRequest request)
	{
		return new HomeIndexGetResponse
			{
				ViewModel = new HomeIndexGetViewModel()
			};
	}
