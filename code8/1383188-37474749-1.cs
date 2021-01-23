        public async Task<TEntity> SelectById(TKey id)
        {
            var idEquals = KeyedBaseModel<TEntity, TKey>.IdEquals(id);
            return await Context.Set<TEntity>().FirstOrDefaultAsync(idEquals);
        }
