    // POST api/values
    [HttpPost]
    public void Post([FromBody] StoryAddRequest request)
    {
        if (request != null)
        {
            Story story = new Story
            {
                content = request.Value,
                timeOfAdding = DateTime.Now,
                numberOfViews = 0
            };
            STORIES.Add(story);
        }
    }
