    public static class QuestionableExtensions
    {
        public static bool EqualsAllOf<T>(this T value, params T[] collection) where T : IEquatable<T>
        {
            return collection.All(t => value.Equals(t));
        }
    }
    public class MyClass 
    {
        public void MyMethod()
        {
            if (4.EqualsAllOf(2 * 2, 2 + 2)) { ... }
        }
    }
