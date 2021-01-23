    [Serializable]
    public class Elements<T>
    {
        public List<T> elementsList { get; set;}
        [NonSerialized]
        Expression<Func<int, bool>> lambda = num => num < 5;
    }
