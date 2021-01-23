    public abstract class NavEntityController<ChildEntity, GenericNavService_T_Entity>
            where ChildEntity : NavObservableEntity<GenericNavService_T_Entity>
    {
        public abstract T ReadAll<T>(bool forceUpdate = false)
                where T : INavObservableCollection<ChildEntity>;
        //others
    }
