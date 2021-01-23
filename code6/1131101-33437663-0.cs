        public List<T> GetAllItemsFromBucket(string bucketPath)
        {
            var index = ContentSearchManager.GetIndex("content_index");
            using (var context = index.CreateSearchContext())
            {
                var results = context.GetQueryable<T>().Where(x => x.Path.StartsWith(bucketPath)).ToList();
                foreach (var result in results) _service.Map(result);
                return results;
            }
        }
