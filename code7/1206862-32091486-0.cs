        public interface ICommandGeneric
    {
        void execute();
    }
    public class CommandOnModel1 : ICommandGeneric
    {
        private Model1 model;
        public CommandOnModel1(Model1 model)
        {
            this.model = model;
        }
        public void execute()
        {
            System.Diagnostics.Debug.WriteLine(model.ToString());
        }
    }
    public interface ICommandFactory <in ModelType>
    {
        string CommandName { get; }
        string Description { get; }
        ICommandGeneric MakeCommand(ModelType model, string parameter1);
    }
    public class Model1
    {
    }
    public class Model1CommandFactory : ICommandFactory<Model1>
    {
        public string CommandName
        {
            get { return "CommandOnModel1"; }
        }
        public string Description
        {
            get { return "I do stuff on Model1"; }
        }
        public ICommandGeneric MakeCommand(Model1 model, string parameter1)
        {
            return new CommandOnModel1(model);
        }
    }
