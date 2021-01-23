                foreach (var item in cv)
                {
                  if (cv.Any(x => m.movieTitle.ToUpper() == Filter.ToUpper()  )
                     { item.movieTitle = txtSearchMovie.Text;}
                  if (cv.Any(x => m.movieDirector.ToUpper() == Filter.ToUpper()  )
                     { item.movieDirector = txtSearchMovie.Text;}
                  if (cv.Any(x => m.movieActor.ToUpper() == Filter.ToUpper()  )
                     { item.movieActor = txtSearchMovie.Text;}
                  if (cv.Any(x => m.movieGenre.ToUpper() == Filter.ToUpper()  )
                     { item.movieGenre = txtSearchMovie.Text;}
                  Movies.Add(item);
                }
