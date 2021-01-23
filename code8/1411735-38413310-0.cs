        public void UpdateEntity(T entity, bool isDetectChange = false)
        {
            if (isDetectChange)
            {
                this._context.ChangeTracker.DetectChanges();
            }
            this._context.Entry(entity).State = EntityState.Modified;
        }
