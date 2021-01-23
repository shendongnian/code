    public class SocialRepository
    {
        public async Task InsertIfNotExists<TEntity>(TEntity obj) where TEntity : Social
        {
            var profile = await MobileService.GetTable<TEntity>().FirstOrDefault(p => p.uuid == obj.uuid);
            if (profile == null)
            {
                await MobileService.GetTable<TEntity>().InsertAsync(obj);
            }
        }
    }
