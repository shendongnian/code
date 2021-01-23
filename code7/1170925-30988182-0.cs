    public async Task AddAsync()
    {
        if (!string.IsNullOrEmpty(word))
        {
            BlackListItem blackListItem =
                new BlackListItem()
                {
                    Word = word,
                    CreatedAt = DateTime.Now
                };
            var blackListItemRepository = new MongoDbRepository<BlackListItem>();
            await blackListItemRepository.InsertAsync(blackListItem);
            Word = string.Empty;
            GetBlackListItems();
        }
    }
