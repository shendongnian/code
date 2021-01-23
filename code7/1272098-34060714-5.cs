    //From ListBox
    var fromSelection = new List<string>("Comedy", "Drama");
    
    //Fetch from table
    var categoryListToAdd = movie.MovieCategories.Where(x => fromSelection.Contains(x.Name)).Select(x => x).ToList();
    
    if(categoryListToAdd.Count > 0)
    {
        //Existing categories of the movie.
        var categoryList = movie.MovieCategories.Select(x => x).ToList();
    
        
        //Remove the related records.
        if(categoryList.Count > 0)
           categoryList.ForEach(x => _movieReviewEntities.MovieCategories.Remove(x));
    
        //Then add the selected categories. 
        categoryListToAdd.ForEach(x => _movieReviewEntities.Add(x));
    }
