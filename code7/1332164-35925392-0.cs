    public class PointGroup<T> : IPointGroup<T> where T : IPoint
    {
        // implicit implementation of IPointGroup<T>.Add(T)
        public void Add(T y) { … }
        // explicit implementation of IPointGroup.Add(IPoint)
        void IPointGroup.Add(IPoint x)
        {
            Add((T)x);
        }
    }
