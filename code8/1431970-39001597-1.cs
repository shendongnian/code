    var filterFragment = new FilterFragment();
    // get the filter attributes
    filterFragment.Searched += (s, ea) =>
    {
       var eventArgs = ea as FilterAppliedEventArgs;
       LoadFilteredMembers(eventArgs.FilterObject);
    };
    FragmentManager.BeginTransaction()
       .AddToBackStack(null)
       .Replace(Resource.Id.members_filterFrame, filterFragment)
       .Commit();
