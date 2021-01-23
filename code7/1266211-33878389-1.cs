    public class PositionFactory
    {
        private Dictionary<int, Type> _positions;
        public PositionFactory()
        {
            _positions = new Dictionary<int, Type>();
        }
        public void RegisterPosition<PositionType>(int id) where PositionType : Position
        {
            _positions.Add(id, typeof(PositionType));
        }
        public Position Get(int id)
        {
            return (Position) Activator.CreateInstance(_positions[id]);
        }
    }
