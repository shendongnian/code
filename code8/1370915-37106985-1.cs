    public class Test {
        public void TestMethod<TFrom, TTo>(Expression<Func<TTo, object>> property) {
            var memberName = property.GetMemberInfo().Name;
            //...other code
        }
    }
