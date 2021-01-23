    using Moq;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    public static class MockDbSet {
        public static Mock<DbSet<T>> Create<T>(params T[] elements) where T : class {
            return elements.AsDbSetMock();
        }
    }
    public static class MockDbSetExtensions {
        public static Mock<DbSet<T>> AsDbSetMock<T>(this IEnumerable<T> list) where T : class {
            IQueryable<T> queryableList = list.AsQueryable();
            Mock<DbSet<T>> dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryableList.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryableList.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(queryableList.GetEnumerator());
            return dbSetMock;
        }
    }
