    [Test]
    public void TestCompareNewWithOld()
    {
        var oldObject = new SomeClass() {
            Items = new List<SomeItem>() {
                new SomeItem() { TheKey = 1, SomeValue = "A"},
                new SomeItem() { TheKey = 2, SomeValue = "B"},
                new SomeItem() { TheKey = 3, SomeValue = "C"},
                new SomeItem() { TheKey = 4, SomeValue = "D"},
            }
        };
        var newObject = new SomeClass() {
            Items = new List<SomeItem>() {
                new SomeItem() { TheKey = 3, SomeValue = "W"},
                new SomeItem() { TheKey = 4, SomeValue = "V"},
                new SomeItem() { TheKey = 5, SomeValue = "U"},
                new SomeItem() { TheKey = 6, SomeValue = "T"},
            }
        };
        var added = new List<object>();
        var removed = new List<object>();
        CompareNewWithOld(oldObject, newObject, added, removed);
        Assert.That(removed, Is.EquivalentTo(new[] {
            oldObject.Items[0],  //A
            oldObject.Items[1]   //B
        }));
        Assert.That(added, Is.EquivalentTo(new[] {
            newObject.Items[2],  //U
            newObject.Items[3]   //T
        }));
    }
