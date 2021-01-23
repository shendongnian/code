    public abstract class NavEntityController<ChildEntity> where ChildEntity : NavObservableEntity
    {
        protected abstract void Delete(ChildEntity line);
        protected abstract void Update(ChildEntity line);
        protected abstract void Create(ChildEntity line);
        ... rest of class
