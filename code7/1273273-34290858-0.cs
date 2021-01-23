    List<RestaurantViewModel> listViewModel = new List<RestaurantViewModel>();
    
    var model =  _db.Restaurants.Include("Reviews").ToList().ForEach((item) =>
                {
                    RestaurantViewModel viewmodel = new RestaurantViewModel();
    
                   viewmodel.ID = item.ID
                   viewmodel.NumberofReviews = item.Reviews.Count;
                   ....
    
                    listViewModel.Add(viewmodel);
    
                });
