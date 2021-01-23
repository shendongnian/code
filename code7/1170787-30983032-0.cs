    public class MaxItemsAttribute : ValidationAttribute
    {
        private readonly int _max;
        public MaxItemsAttribute(int max) {
            _max = max;
        }
        public override bool IsValid(object value) {
            var list = value as IList;
            if (list == null)
                return false;
            if (list.Count > _max)
                return false;
            return true;
        }
    }
