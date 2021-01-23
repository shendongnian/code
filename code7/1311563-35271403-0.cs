    public class Assertion {
        public Assertion AssertEquals(object actual, object expected) {
            // TODO: call your framework Assert.AreEqual() here
            Assert.AreEqual(a, b);
            return this;
        }
    }
    
    // and now you can do something like this :
    new Assertion()
        .AssertEquals("objectA", object.A)
        .AssertEquals("objectB", object.B);
