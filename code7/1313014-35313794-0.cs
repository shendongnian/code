    public abstract class %YOUR_NAME%CategoryBaseCommandHandler<T> : ICommandHandler<T>
    {
        public override void Handle(T command)
        {
            var category = LoadCategory(command);
            MapProcessor.Map(command, category);
            UnitOfWork.Commit();
            Registrator.Committed += () =>
            {
                command.Id = category.Id;
            };
        }
        
        protected abstract Category LoadCategory(T command);
    } 
