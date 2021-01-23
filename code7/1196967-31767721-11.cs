    public class SourceA : Entity<SourceA, SourceA.DomainObject, SourceA.IRepository>
    {
        public class DomainObject : BaseDomainObject
        {
            public  string  Name;
            public  int     Age;
        }
        public interface IRepository : IBaseRepository {}
        public class Repository : BaseRepository, IRepository {}
    }
    public class SourceB : Entity<SourceB, SourceB.DomainObject, SourceB.IRepository>
    {
        public class DomainObject : BaseDomainObject
        {
            public  string  Name;
            public  decimal Weight;
        }
        public interface IRepository : IBaseRepository {}
        public class Repository : BaseRepository, IRepository {}
    }
    public class SourceC : Entity<SourceC, SourceC.DomainObject, SourceC.IRepository>
    {
        public class DomainObject : BaseDomainObject
        {
            public  Guid    Id;
            public  string  Name;
        }
        public interface IRepository : IBaseRepository {}
        public class Repository : BaseRepository, IRepository {}
    }
