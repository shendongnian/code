    public virtual void Update(T updatedObject, int key, params Expression<Func<T, IEnumerable>>[] navigationProperties) {
        if (updatedObject == null) {
            return;
        }
        using (var databaseContext = new U()) {
            databaseContext.Database.Log = Console.Write;
            T foundEntity = databaseContext.Set<T>().Find(key);
            var entry = databaseContext.Entry(foundEntity);
            entry.CurrentValues.SetValues(updatedObject);
            foreach (var prop in navigationProperties) {
                string memberName;
                var member = prop.Body as MemberExpression;
                if (member != null)
                    memberName = member.Member.Name;
                else throw new Exception("One of the navigationProperties is not a member access expression");
                var collection = entry.Collection(memberName);
                collection.Load();
                collection.CurrentValue = typeof (T).GetProperty(memberName).GetValue(updatedObject);
            }
            databaseContext.SaveChanges();
        }
    }
