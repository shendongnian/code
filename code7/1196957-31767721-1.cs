    public class SourceA : Entity<SourceA, SourceA.DomainObject, SourceA.IRepository>
    {
        public class DomainObject : BaseDomainObject {}
        public interface IRepository : IBaseRespository {}
        public class Repository : BaseRepository, IRepository {}
    }
    public class SourceB : Entity<SourceB, SourceB.DomainObject, SourceB.IRepository>
    {
        public class DomainObject : BaseDomainObject {}
        public interface IRepository : IBaseRespository {}
        public class Repository : BaseRepository, IRepository {}
    }
    public class SourceC : Entity<SourceC, SourceC.DomainObject, SourceC.IRepository>
    {
        public class DomainObject : BaseDomainObject {}
        public interface IRepository : IBaseRespository {}
        public class Repository : BaseRepository, IRepository {}
    }
