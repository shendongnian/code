            var pendingChanges = GetContext().ChangeTracker.Entries<T>().Select(e => e.Entity).ToList();
            foreach (var entity in pendingChanges)
            {
                entity.DateModified = DateTime.Now
            }
