    public interface IDbTools<in TCommand>
        where TCommand: IDbCommand
    {
        void PrepareAndExecuteQuery(TCommand command);
    }
