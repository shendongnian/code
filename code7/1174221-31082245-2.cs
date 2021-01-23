    public async Task<IEnumerable<Node>> GetNode(string id = null)
    {
        return await Query()
            .Where(x => x.ParentId == id)
            .Include(x => x.Children)
            .ToListAsync();
    }
