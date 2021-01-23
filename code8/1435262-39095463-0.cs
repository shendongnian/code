    [Route("api/v1/topics")]
    public IEnumerable<Topic> Get()
        {
            var topics = _repo.GetTopics()
                            .OrderByDescending(t => t.Created)
                            .Take(25)
                            .ToList();
            return topics;
        }
