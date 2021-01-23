    // define 2 separate requests
    SearchResource.ListRequest listRequestMedium = SearchResource.List("snippet");
    listRequestMedium.Q = query;
    listRequestMedium.Type = "video";
    listRequestMedium.VideoDuration = SearchResource.ListRequest.VideoDurationEnum.Medium;
    SearchResource.ListRequest listRequestShort = SearchResource.List("snippet");
    listRequestShort.Q = query;
    listRequestShort.Type = "video";
    listRequestShort.VideoDuration = SearchResource.ListRequest.VideoDurationEnum.Short;
    SearchListResponse shortVideos = listRequestShort.Fetch();
    SearchListResponse mediumVideos = listRequestMedium.Fetch();
    // merge the 2 result lists and iterate over them
    foreach (SearchResult searchResult in shortVideos.Items.Union(mediumVideos.Items).ToList()) {
        // do something with the videos
    }
