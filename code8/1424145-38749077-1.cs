        private Mock<DbSet<T>> GetDbSetMock<T>(IEnumerable<T> items = null) where T : class
        {
            if (items == null)
            {
                items = new T[0];
            }
            var dbSetMock = new Mock<DbSet<T>>();
            var q = dbSetMock.As<IQueryable<T>>();
            q.Setup(x => x.GetEnumerator()).Returns(items.GetEnumerator);
            return dbSetMock;
        }
