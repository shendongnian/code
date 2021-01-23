    public interface IDatabase
    {
        void setItem( IElement task );  //this works fine
        List<IElement> listTasks<IElement>();
    }
