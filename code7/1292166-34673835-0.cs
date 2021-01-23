    CachedSet<DbView>.Get(this, DbViewDbSet,
        (DbView entity) => true,
        (DbSet<DbView> set) =>
        {
            var k = set.Select(e => e.Value.LastModified).Max();
            return g => g.LastModified >= k;
        });
