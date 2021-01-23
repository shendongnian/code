        public async Task DeleteAudit(int mInt)
        {
            var ctx = new _AuditRepository(connectionString);
            var audit = await ctx.FindBy(a => a.MInt == mInt).FirstOrDefaultAsync();
            _AuditRepository.Delete(audit);
            await ctx.SaveChangesAsync();
            ctx.Dispose()
        }
