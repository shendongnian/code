    switch (sortOrder.ToLower()) {
        case "name_desc":
            movies =  movies.OrderByDescending(s => s.Title);
            break;
        case "date":
            movies = movies.OrderBy(s => s.Print);
            break;
        default:
            movies = movies.OrderByDescending(s => s.DateAdd);
            break;
    }
