    public interface ISqlUtil {
        T SomeGenericMethod<T>(T args);
        int SomeMethodToIntercept();
    }
    public class ConcreteSqlUtil : ISqlUtil {
        public T SomeGenericMethod<T>(T args){
            return args;
        }
        public int SomeMethodToIntercept() {
            return 42;
        }
    }
    public class SqlUtilFactory {
        public static ISqlUtil CreateSqlUtil() {
            var rVal = new ConcreteSqlUtil();
            // Some Complex setup
            return rVal;
        }
    }
