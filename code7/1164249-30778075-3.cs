    var model = new MovieViewModel();
    model = Mapper.Map<MovieContent, MovieViewModel>(movie);
    
    //Check if Null
    if (images.backdrops != null)
    {
        model.Images = Mapper.Map<IEnumerable<Backdrop>, IEnumerable<Images>>(images.backdrops);
    }
