        public async Task<object> GetData(int page, int pagesize)
        {
            return await Task.Factory.StartNew<object>(() =>
            {
                return dataset.Skip(page * pagesize).Take(pagesize);
            });
        }
