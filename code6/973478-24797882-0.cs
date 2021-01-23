            [GET("api/libraries", Precedence = 2)]
            [System.Web.Http.HttpGet]
            public Library QueryLibraryByLibraryId(string libraryId) { }
    
            [GET("api/libraries/bookStatus/{libraryId:long}", Precedence = 1)]
            [System.Web.Http.HttpGet]
            public Dictionary<string, Dictionary<string, string>> QueryBookStatus(long libraryId) { }
