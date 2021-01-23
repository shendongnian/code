    public class YourContext : DbContext, IDbContext
    {
        public IDbSet<Student> Students {get;set;}
    }
    
    public interface IDbContext
    {
        IDbSet<Student> Students;
    }
    // Util for creating a testable context.
    public class ContextUtils
    {
        internal static IDbSet<T> GetMockDbSet<T>(IEnumerable<T> data) where T : class
        {
            IQueryable<T> queryable = data.AsQueryable();
            IDbSet<T> dbSet = MockRepository.GenerateMock<IDbSet<T>, IQueryable>();
            dbSet.Stub(m => m.Provider).Return(queryable.Provider);
            dbSet.Stub(m => m.Expression).Return(queryable.Expression);
            dbSet.Stub(m => m.ElementType).Return(queryable.ElementType);
            dbSet.Stub(m => m.GetEnumerator()).Return(queryable.GetEnumerator());
            return dbSet;
        }
        public static IDbContext GetMockDbContext()
        {
            var dbContext = MockRepository.GenerateMock<IDbContext>();
            dbContext.Stub(x => x.Student).PropertyBehavior();
            dbContext.Students = GetMockDbSet(GetStudents());
            return dbContext;
        }
        private static IEnumerable<Student> GetStudents()
        {
            // Create some mock data.
            return new List<Student>
            {
                new Student()
                {
                    StudentID = 1,
                    Name = "Student One",
                },
                new Student()
                {
                    StudentID = 2,
                    Name = "Student Two",
                },
                new Student()
                {
                    StudentID = 3,
                    Name = "Student Three",
                }
            };
        }
        
    }
