    public interface IRegionManager
    {
        /// <summary>
        /// Gets a collection of <see cref="IRegion"/> that identify each region by name. You can use this collection to add or remove regions to the current region manager.
        /// </summary>
        IRegionCollection Regions { get; }
            
        [...]
    }
