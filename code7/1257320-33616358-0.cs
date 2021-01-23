    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace UnitTestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {            
                int[] CostNextUpgrade = new int[5];
                int[] NumberOwned = new int[5];
                for (int i = 0; i < CostNextUpgrade.Length; i++)
                {
                    CostNextUpgrade[i] = i;
                }
                // Buy the max number of upgrade number 2 then exit
                int n = 0;
                bool BuyMax = n == 0; // BuyMax is true if n == 0
                int UpgradeNumber = 2;
                int TotalCash = 10;
            
                while (CostNextUpgrade[UpgradeNumber] <= TotalCash && 
                    (BuyMax == true || n >= 1))
                {
                    TotalCash -= CostNextUpgrade[UpgradeNumber];
                    NumberOwned[UpgradeNumber] += 1;
                    n--;
                }
                // Assert we can't afford another upgrade
                Assert.IsTrue(TotalCash < CostNextUpgrade[UpgradeNumber]); 
            }
            [TestMethod]
            public void TestMethod2()
            {
                int[] CostNextUpgrade = new int[5];
                int[] NumberOwned = new int[5];
                for (int i = 0; i < CostNextUpgrade.Length; i++)
                {
                    CostNextUpgrade[i] = i;
                }
                // Buy 3 of upgrade number 2
                int n = 3;
                bool BuyMax = n == 0; // BuyMax is true if n == 0
                int UpgradeNumber = 2;
                int TotalCash = 10;
                while (CostNextUpgrade[UpgradeNumber] <= TotalCash &&
                    (BuyMax == true || n >= 1))
                {
                    TotalCash -= CostNextUpgrade[UpgradeNumber];
                    NumberOwned[UpgradeNumber] += 1;
                    n--;
                }
                // Assert we bought exactly 3
                Assert.AreEqual(NumberOwned[UpgradeNumber], 3);
            }
        }
    }
