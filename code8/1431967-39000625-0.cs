    FragmentManager.BeginTransaction()
    .AddToBackStack(null)
    .Replace(Resource.Id.members_filterFrame, new FilterFragment((parameter) => {
    	// Do something with the given parameter
    }))
    .Commit();
