    [TestClass]
    public class MaterialsTests
    {
        [TestMethod]
        public void Contains_wroks_as_expected()
        {
            var filter = Materials.all;
            Assert.IsTrue(filter.Contains(Material.metal));
        }
    }
    
    public static class Extensions
    {
        public static bool Contains(this Materials filter, Material material)
        {
            var valueToFilter = (Materials)(int)(material);
            return filter.HasFlag(valueToFilter);
        }
    }
    
    public enum Material
    {
        wood = 1,
        metal = 2,
        plastic = 4
    }
    
    [Flags]
    public enum Materials
    {
        none = 0,
        wood = 1,
        metal = 2,
        plastic = 4,
        all = 7
    }
