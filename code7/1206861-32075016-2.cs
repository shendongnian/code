    public interface IModel
    {
        void UpdateModel();
    }
    public class Model1 : IModel
    {
       public string Name {get;set;}
       public int Age {get;set;}
       // implement updating of the model
       public void UpdateModel() {...do model update...}
    }
    
    
    public class Model2 : IModel
    {
        public DateTime Time {get;set;}
        public double Price {get;set}
       // 'dummy' implement updating of the model if this model does not supports updating
       public void UpdateModel() { // do nothing or throw NotImplementedException(); }
    }
    public interface ICommandFactory
    {
        string CommandName { get; }
        string Description { get; }
    
        ICommand MakeCommand( IModel model );
    }
