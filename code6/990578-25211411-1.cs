       public class Foo
       {
           public virtual void Bar(int input, out string val1, out string val2)
           {
               val1 = "Hello";
               val2 = "Howdy";
           }
       }
       [Fact]
       public void MyTest()
       {
           var foo = new Mock<Foo>();
           var val1 = "Hi";
           var val2 = "Hey";
           foo.Setup(x => x.Bar(1, out val1, out val2));
           var val3 = "Hi!";
           var val4 = "Hey!";
           foo.Setup(x => x.Bar(It.IsInRange(2, int.MaxValue, Range.Inclusive), out val3, out val4));
           string test1, test2;
           foo.Object.Bar(1, out test1, out test2);
           Assert.Equal(val1, test1);
           Assert.Equal(val2, test2);
           foo.Object.Bar(2, out test1, out test2);
           Assert.Equal(val3, test1);
           Assert.Equal(val4, test2);
       }
