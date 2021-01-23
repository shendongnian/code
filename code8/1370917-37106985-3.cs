    public class Test {
        public void TestMethod<TFrom, TTo>(Expression<Func<TTo>> property) {
            var memberName = property.GetMemberInfo().Name;
            //...other code
        }
    }
