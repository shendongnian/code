    public class ApplicationGestureShortList:ObjectDataProvider
    {
        public List<object> GetShortListOfApplicationGestures(Type type)
        {
            return
                Enum.GetValues(type)
                    .OfType<object>()
                    .Where(gesture => gesture.ToString().ToLowerInvariant().Contains('w'))
                    .ToList();
        }
    }
