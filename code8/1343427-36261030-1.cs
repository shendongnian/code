    public class Class
    {
        public override bool Equals(object o) => base.Equals(o);
    }
    var m = Mock.Of<Class>(c =>
        c.Equals(It.IsAny<object>()) == true
        );
    Assert.True(m.Equals(null));
