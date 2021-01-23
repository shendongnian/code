    [TestFixture]
    public class MyClassTest {
      [Test]
      public void NewItemsAreAddedWhenCheckedItemsIsEmpty() {
        // arrange
        Item expectedItem = new Item();
        MyClass tester = new MyClass();
        tester.Q.Add(expectedItem);
        // act
        tester.TransferItems();
    
        // assert
        int actualCount = tester.CheckedItems.Count;
        int expectedCount = 1;
    
        Assert.Equals(actualCount, expectedCount);
    
        var actualItem = tester.CheckedItems[0];
        Assert.AreSame(actualItem, expectedItem);
      }
    
      [Test]
      public void NewItemsAreAddedWhenCheckedItemsContainsElements() {
        // arrange
        Item expectedItem = new Item();
        MyClass tester = new MyClass();
        tester.Q.Add(expectedItem);
        tester.CheckedItems.Add(new Item());
        // act
        tester.TransferItems();
    
        // assert
        int actualCount = tester.CheckedItems.Count;
        int expectedCount = 2;
    
        Assert.Equals(actualCount, expectedCount);
    
        var expectedContains = tester.CheckedItems.Contains(expectedItem);
        Assert.IsTrue(expectedContains);
      }
    }
    
