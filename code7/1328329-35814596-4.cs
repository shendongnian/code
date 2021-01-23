    public interface IService<TParam>
       where TParam : ParamBase
    {
        void ApplyChanges(TParam parameters);
    }
    public abstract class ServiceBase<TParam> : IService<TParam>
        where TParam : ParamBase
    {
        public virtual void ApplyChanges(TParam parameters)
        { }
    }
    public class Service : ServiceBase<ParamA>
    {
        public override void ApplyChanges(ParamA parameters)
        {
            Console.WriteLine(parameters.Param2);
        }
    }
