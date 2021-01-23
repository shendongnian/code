    var imageQuery = bingContainer.Image(keyword, null, null, null, null, null, null);
    string imageFilters;
    switch (i)
    {
        case 0:
            imageFilters= ("Size:Small");
            break;
        case 1:
            imageFilters= ("Size:Medium");
            break;
        case 2:
            imageFilters= ("Size:Large");
            break;
    }
    imageQuery = query.AddQueryOption("ImageFilters", string.Concat("\'", System.Uri.EscapeDataString(imageFilters), "\'"));
