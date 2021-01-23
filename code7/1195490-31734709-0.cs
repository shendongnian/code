      var searchPredicate = PredicateBuilder.False<Songs>();
    
      var strArray = new[] {"aa", "bb"};
    
      foreach (string str in strArray) {
        var closureVariable = str;
        searchPredicate =
         searchPredicate.Or(songsVar => songsVar.Tags.Any(tagVar => tagVar.TagName == closureVariable));
      }
    
      var songs = new List<Songs> {
        new Songs {Tags = new List<Tag> {new Tag {TagName = "aa"}}},
        new Songs {Tags = new List<Tag> {new Tag {TagName = "bb"}}},
        new Songs {Tags = new List<Tag> {new Tag {TagName = "aa"}, new Tag {TagName = "cc"}}},
        new Songs {Tags = new List<Tag> {new Tag {TagName = "cc"}, new Tag {TagName = "dd"}}}
      };
    
      var res = songs.Where(searchPredicate.Compile());
