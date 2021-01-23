    public interface IStrategy
    {
        IStrategyResult Execute(ISerializable info = null);
    }
    public interface IStrategyResult
    {
        bool IsValid { get; }
        dynamic Value { get; }
    }
    public class StrategyResult<T> : IStrategyResult
    {
        public T Value { get; private set; }
        public StrategyResult(T value) { this.Value = value; }
        public bool IsValid { get { throw new NotImplementedException(); } }
        dynamic IStrategyResult.Value { get { return this.Value; } }
    }
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RegisterActionAttribute : Attribute
    {
        public List<string> Dependencies { get; private set; }
        public RegisterActionAttribute(params string[] depdencies)
        {
            this.Dependencies = new List<string>(depdencies);
        }
    }
    public class StrategyAction
    {
        public string Name;
        public List<string> Dependencies;
    }
    public abstract class BasePlugin<T> : IStrategy
    {
        public IStrategyResult Execute(ISerializable info = null)
        {
            return new StrategyResult<T>(this.execute(info));
        }
        protected abstract T execute(ISerializable info);
    }
