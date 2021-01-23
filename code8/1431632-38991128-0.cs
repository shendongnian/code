    namespace UnitTestProject
    {
        [TestClass]
        public class CompareTwoGenericList
        {
            [TestMethod]
            public void TestMethod1()
            {
                var coll = GetCollectionOne();
                var col2 = GetCollectionTwo();
                //Gives the equal value
                var commonValue = coll.Intersect(col2, new DemoComparer()).ToList();
                //Difference
                var except=coll.Except(col2, new DemoComparer()).ToList();
            }
            public List<Demo> GetCollectionOne()
            {
                List<Demo> demoTest = new List<Demo>()
                {
                    new Demo
                    {
                        id=1,
                        color="blue",
                    },
                    new Demo
                    {
                        id=2,
                        color="green",
                    },
                    new Demo
                    {
                        id=3,
                        color="red",
                    },
                };
                return demoTest;
            }
            public List<Demo> GetCollectionTwo()
            {
                List<Demo> demoTest = new List<Demo>()
                {
                    new Demo
                    {
                        id=1,
                        color="blue",
                    },
                    new Demo
                    {
                        id=2,
                        color="green",
                    },
                    new Demo
                    {
                        id=4,
                        color="red",
                    },
                };
                return demoTest;
            }
        }
        // Custom comparer for the Demo class
        public class DemoComparer : IEqualityComparer<Demo>
        {
            // Products are equal if their color and id are equal.
            public bool Equals(Demo x, Demo y)
            {
                //Check whether the compared objects reference the same data.
                if (Object.ReferenceEquals(x, y)) return true;
                //Check whether any of the compared objects is null.
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;
                //Check whether the demo properties are equal.
                return x.color == y.color && x.id == y.id;
            }
            // If Equals() returns true for a pair of objects
            // then GetHashCode() must return the same value for these objects.
            public int GetHashCode(Demo demo)
            {
                //Check whether the object is null
                if (Object.ReferenceEquals(demo, null)) return 0;
                //Get hash code for the color field if it is not null.
                int hashColor = demo.color == null ? 0 : demo.color.GetHashCode();
                //Get hash code for the id field.
                int hashId = demo.id.GetHashCode();
                //Calculate the hash code for the product.
                return hashColor ^ hashId;
            }
        }
    }
