    public static class MockQueryableExtensions {
        /// <summary>
        /// Converts a generic <seealso cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/>  to a <see cref="Moq.Mock"/> implementation of Queryable list 
        /// </summary>
        public static Mock<T> AsQueryableMock<T, TItem>(this Mock<T> queryableMock, IEnumerable<TItem> list)
            where T : class,IEnumerable<TItem> {
            var queryableList = list.AsQueryable();
            queryableMock.As<IQueryable<TItem>>().Setup(x => x.Provider).Returns(queryableList.Provider);
            queryableMock.As<IQueryable<TItem>>().Setup(x => x.Expression).Returns(queryableList.Expression);
            queryableMock.As<IQueryable<TItem>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
            queryableMock.As<IQueryable<TItem>>().Setup(x => x.GetEnumerator()).Returns(queryableList.GetEnumerator());
            return queryableMock;
        }
    }
