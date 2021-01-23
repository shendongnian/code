        public virtual T GetAtTime(DateTime time)
        {
            if (_source is IQueryable<T>)
                return ((IQueryable<T>)_source)
                    .Where(t => t.StartTime <= time)
                    .OrderByDescending(t => t.StartTime)
                    .FirstOrDefault();
            else
                return _source
                    .Where(t => t.StartTime <= time)
                    .OrderByDescending(t => t.StartTime)
                    .FirstOrDefault();
        }
