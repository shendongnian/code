    [TestClass()]
    public class WaterContainer
    {
        [TestMethod()]
        public void WhenWaterContainerIsEmpty_FillingItUp_CausesCorrectWaterLevel() {
            // There seems to be no relationship between the container
            // and the tap - so how will the tap cause any change
            // to the container?
            WaterContainer waterC = new WaterContainer(0);
            WaterTap tap = new WaterTap();
    
            // The method that you shared with us is called:
            // FillUpWater, but this is calling FillUpContainer
            waterC= tap.FillUpContainer();
            // You create a variable named:
            // waterC, but use WaterC here (C# is case sensitive)
            Assert.AreEqual(5, WaterC.Level);
        }
    }
