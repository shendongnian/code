    public interface IState<out TObject, in TState>
        where TObject : IStatefulObject<TObject, TState>
        where TState : IState<TObject, TState>
    {
    }
    public interface IStatefulObject<in TObject, out TState>
        where TObject : IStatefulObject<TObject, TState>
        where TState : IState<TObject, TState>
    {
    }
    public abstract class AbstractState<TObject> : IState<TObject, AbstractState<TObject>>
        where TObject : IStatefulObject<TObject, AbstractState<TObject>>
    {
        protected TObject Object { get; private set; }
        public AbstractState(TObject obj)
        {
            Object = obj;
        }
    }
    public abstract class StatefulObject<TState> : IStatefulObject<StatefulObject<TState>, TState>
        where TState : IState<StatefulObject<TState>, TState>
    {
        protected TState State { get; set; }
    }
    public class Monster : StatefulObject<MonsterState>
    {
        public Monster()
        {
            State = new IdleMonsterState(this);
        }
    }
    public abstract class MonsterState : AbstractState<Monster>
    {
        protected MonsterState(Monster monster)
            : base(monster)
        {
        }
    }
    public class IdleMonsterState : MonsterState
    {
        public IdleMonsterState(Monster monster)
            : base(monster)
        {
        }
    }
