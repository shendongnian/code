    public class LocationController : ApiController
    {
        UserLogic _userLogic;
        public LocationController()
        {
            _userLogic = new UserLogic();
        }
        public void PostLocationToUser(LocationViewModel locationViewModel)
        {
            _userLogic.AddLocationToUser(locationViewModel.UserId, locationViewModel.Location);
        }
    }
