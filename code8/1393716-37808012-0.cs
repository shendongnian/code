    public class MyAttribute : Attribute { }
    public interface IHaveAttributes {
        [My] string Sample { get; set; }
    }
    public class HaveAttributes : IHaveAttributes {
        [My] public virtual string Sample { get; set; }
    }
    public class NoAttributes : IHaveAttributes {
        public virtual string Sample { get; set; }
    }
    [Test]
    public void TestAttributes()
    {
        // WORKS for class:
        var sub = Substitute.For<HaveAttributes>();
        var sampleProp = sub.GetType().GetProperty("Sample");
        var attributes = Attribute.GetCustomAttributes(sampleProp, typeof(MyAttribute));
        Assert.AreEqual(1, attributes.Length);
        // WORKS directly from interface:
        var sampleInterfaceProp = typeof(IHaveAttributes).GetProperty("Sample");
        var attributes2 = Attribute.GetCustomAttributes(sampleInterfaceProp, typeof(MyAttribute));
        Assert.AreEqual(1, attributes2.Length);
        // Does NOT go from interface through to class (even non-substitutes):
        var no = new NoAttributes();
        var sampleProp2 = no.GetType().GetProperty("Sample");
        var noAttributes = Attribute.GetCustomAttributes(sampleProp2, typeof(MyAttribute));
        Assert.IsEmpty(noAttributes);
    }
