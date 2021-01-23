    internal static class EntityExtensions
    {
        public static TSpecificManager ToEntity<TSpecificManager>(this ManagerViewModel managerViewModel)
            where TSpecificManager : new()
        {
            // Do your conversion based on ManagerViewModel
            return new TSpecificManager();
        }
    }
