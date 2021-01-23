    class BasePartListViewModel<T> : ListViewModel
        where T : Part
    {
        private static PartType PartTypeOfT;
        static BasePartListViewModel()
        {
            var attr = typeof(T).GetCustomAttributes(typeof(PartTypeAttribute), true)
                .FirstOrDefault() as PartTypeAttribute;
            if (attr != null)
                PartTypeOfT = attr.PartType;
        }
        protected override void OnTreeSelectionChanged(PartType type)
        {
            if (type == PartTypeOfT) {
                ....
            }
        }
    }
