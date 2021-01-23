    public interface IRegionCollection : IEnumerable<IRegion>, INotifyCollectionChanged
    {
        [...]
        /// <summary>
        /// Removes a <see cref="IRegion"/> from the collection.
        /// </summary>
        /// <param name="regionName">Name of the region to be removed.</param>
        /// <returns><see langword="true"/> if the region was removed from the collection, otherwise <see langword="false"/>.</returns>
        bool Remove(string regionName);
        [...]
    }
