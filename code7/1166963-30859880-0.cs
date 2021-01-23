    public override async Task<object> Add(Commune entity)
        {
            // Check Validity.
            CheckValidity(entity);
            // Context.
            Ctx.Set<Commune>().Add(entity);
            Ctx.Set<Province>().Attach(entity.Province);
            await Ctx.SaveChangesAsync();
            // Return.
            return entity;
        }
