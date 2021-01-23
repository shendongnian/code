    var model = new MovieViewModel();
    model = Mapper.Map<MovieContent, MovieViewModel>(movie);
    
    if (images.backdrops != null)
    {
        model.Images = Mapper.Map<IEnumerable<Backdrop>, IEnumerable<Images>>(images.backdrops);
    }
