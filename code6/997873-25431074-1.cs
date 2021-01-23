    List<Result> newList = results.SelectMany(res => res.Reviews.Select(r => new { Result = res, Review = r }))
    		.GroupBy(pair => pair.Review.Name)
    		.Select(grp => grp.First())
    		.GroupBy(pair => pair.Result, pair => pair.Review)
    		.Select(reviews =>
    				{
                        // Here you can create new Result object of use the original one
    					Result result = reviews.Key; // Here is original Result object
    					result.Reviews = reviews.ToList(); // Replacing Reviews list with the filtered one
    					return result;
    				})
    		.ToList();
