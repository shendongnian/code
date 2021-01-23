    public class StudentMap : ClassMap<Students>
    {
        public StudentMap()
        {
                CompositeId()
                    .KeyProperty(x => x.name, "id")
                    .KeyProperty(x => x.name, "name");
                ...
