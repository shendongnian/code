    public class Class {}
    var m = Mock.Of<Class>(c =>
        c.Equals(It.IsAny<object>()) == true
        );
    Assert.True(m.Equals(null));
