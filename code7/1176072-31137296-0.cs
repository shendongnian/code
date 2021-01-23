    public IEnumerable<IQueryable> GetCarsByStatusId(List<int> statusIds = null)
    {
        if (statusIds == null)
        {
            yield return this.Context.ACRViewCars.OrderBy(x => x.Status);
        }
        else if (statusIds != null && statusIds.Count > 0)
        {
            foreach (int id in statusIds)
            {
                yield return this.Context.ACRViewCars.Where(x => x.StatusId == id);
            }
        }
    }
