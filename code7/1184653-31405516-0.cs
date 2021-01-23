        static ICollection<T> Compare<T>(ICollection<T> list1, ICollection<T> list2) where T : IEntity
        {
            List<T> result = new List<T>();
            foreach (T item in list1) if(!list2.Any(e => e.Id == item.Id)) result.Add(item);
            foreach (T item in list2) if (!list1.Any(e => e.Id == item.Id)) result.Add(item);
            return result;
        }
