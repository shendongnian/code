    public class SomeClass
    {
        public List<int> Items { get; set; }
    }
    public void CompareNewWithOld(object oldObject, object newObject, List<object> added, List<object> removed)
    {
        var properties = typeof (SomeClass).GetProperties();
        foreach (PropertyInfo pi in properties)
        {
            object oldValue = pi.GetValue(oldObject), newValue = pi.GetValue(newObject);
            if (pi.PropertyType.IsGenericType && typeof(IEnumerable).IsAssignableFrom(pi.PropertyType))
            {
                HashSet<object> oldSet = new HashSet<object>(((IEnumerable)oldValue).Cast<object>());
                HashSet<object> newSet = new HashSet<object>(((IEnumerable)newValue).Cast<object>());
                HashSet<object> removedSet = new HashSet<object>(oldSet);
                removedSet.ExceptWith(newSet);
                HashSet<object> addedSet = new HashSet<object>(newSet);
                addedSet.ExceptWith(oldSet);
                added.AddRange(addedSet);
                removed.AddRange(removedSet);
            }
        }
    }
    [Test]
    public void TestCompareNewWithOld()
    {
        var oldObject = new SomeClass() {
            Items = new List<int>() {1, 2, 3,  4}
        };
        var newObject = new SomeClass() {
            Items = new List<int>() { 3, 4, 5, 6 }
        };
        var added = new List<object>();
        var removed = new List<object>();
        CompareNewWithOld(oldObject, newObject, added, removed);
        Assert.That(removed, Is.EquivalentTo(new[] { 1, 2 }));
        Assert.That(added, Is.EquivalentTo(new[] { 5, 6 }));
    }
