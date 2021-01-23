    <pre>
     List<MatchingSubstituteViewModel> lstMatchingSubsViewModels = new List<MatchingSubstituteViewModel>();
        foreach (var item in list)
        {
            var substtitute = item.Substitute;
            var subAddress = substtitute.HomeAddress;
            var distance = HomeAddress.GetGeographicDistance(schoolAddress.Longitude, schoolAddress.Latitude, subAddress.Longitude, subAddress.Latitude);
            matchingSubsViewModels = new MatchingSubstituteViewModel()
            {
                Substitute =  item.Substitute, // errors List<MatchingSubstituteViewModel> does not contain a difinition for 'Substitute '
                Distance = distance // errors List<MatchingSubstituteViewModel> does not contain a difinition for 'distance'
            };
         lstMatchingSubsViewModels .add(matchingSubsViewModels );
        }return View(lstMatchingSubsViewModels );
