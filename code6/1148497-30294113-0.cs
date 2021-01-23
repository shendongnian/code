    namespace TestNameSpace {
      public interface IFinder
      {
        IEnumerable<T> GetData<T>(DataStore dataStore);
      }
      public class EmployeeFinder : IFinder {
        public IEnumerable<EmployeeGenericParameter> GetData<EmployeeGenericParameter>(DataStore dataStore) {
            return dataStore.Employees;
        }
      }
      public class DataStore {
        public IEnumerable<EmployeeClass> Employees { get; set;}
      }
      public class EmployeeClass {
      }
    }
