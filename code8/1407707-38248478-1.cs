    public class CatDbQuerier : BaseDbQuerier
    {
        protected override DbEnum Database { get { return DbEnum.CatDatabase; } }
    }
    public class DogDbQuerier : BaseDbQuerier
    {
        protected override DbEnum Database { get { return DbEnum.DogDatabase; } }
    }
    public class TurtleDbQuerier : BaseDbQuerier
    {
        protected override DbEnum Database { get { return DbEnum.TurtleDatabase; } }
    }
