    public abstract class AbstractState
    {
    }
    public abstract class StatefulObject
    {
    }
    public abstract class AbstractState<TObject> : AbstractState
        where TObject : StatefulObject
    {
        protected TObject Object { get; private set; }
        public AbstractState(TObject obj)
        {
            Object = obj;
        }
    }
    public abstract class StatefulObject<TState> : StatefulObject
        where TState : AbstractState
    {
        protected TState State { get; set; }
    }
    public class Monster : StatefulObject<MonsterState>
    {
    }
    public abstract class MonsterState : AbstractState<Monster>
    {
        protected MonsterState(Monster monster)
            : base(monster)
        {
        }
    }
