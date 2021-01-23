    public virtual TEntity GetRandom()
    {
          return DBSet.OrderBy(r => Guid.NewGuid()).Take(1).First();
    }
    public List<TEntity> Random(int amount, int maxprice)
        {
            var list = new List<TEntity>();
            var tempPrice = 0;
            for (int i = 0 ; i < amount; i++)
            {
                var element = GetRandom();
                tempPrice += element.Price;
                if (tempPrice > maxprice)
                {
                    return list;
                }
                list.Add(element);
            }
            return list;
        }
