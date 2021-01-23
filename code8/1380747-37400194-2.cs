    List<Movie> movies = new List<Movie>() { 
				new Movie(){Id = 1, Name = "The Matrix"},
				new Movie(){Id = 2, Name = "Captain America"}
			};
			List<MovieReview> reviews = new List<MovieReview>() 
			{ 
				new MovieReview(){MovieId = 1, Review = 8},
				new MovieReview(){MovieId = 1, Review = 7},
				new MovieReview(){MovieId = 2, Review = 5}
			};
			//var movieReviews = reviews.GroupBy(r => r.MovieId).Select(g => new { MovieId = g.Key, AvgReview = g.Average( r => r.Review) });
			var finalReviews = movies.Join(
				reviews.GroupBy(r => r.MovieId).Select(g => new { MovieId = g.Key, AvgReview = g.Average(r => r.Review) }),
				m => m.Id,
				r => r.MovieId,
				(m, r) => new { Name = m.Name, AvgReview = r.AvgReview });
			foreach (var f in finalReviews.AsEnumerable())
			{ 
				Console.WriteLine(f.Name + " " + f.AvgReview);
			}
			Console.ReadKey();
