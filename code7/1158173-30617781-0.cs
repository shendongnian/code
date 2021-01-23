    public interface ICommandFactory {
        IInsertProjectDAOAction CreateInsertProjectAction(int userId);
    }
    public class CommandFactory : ICommandFactory{
        public IInsertProjectDAOAction CreateInsertProjectAction(int userId) {
            return new InsertProjectDAOAction(/* userId???? */);
        }
    }
