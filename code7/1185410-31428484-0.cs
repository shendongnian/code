    interface IWithId {
        int Id { get; set; }
    }
    class CustomList<T> : List<T> where T : class, IWithId {
        private lastUsedId = 1;
        public void AddObjectWithAutomaticId(T newObject) {
            newObject.Id = lastUsedId++;
            base.Add(newObject);
        }
        public T GetElementById(int id) {
             return base.SingleOrDefault(p => p.Id == id);
        }
    }
