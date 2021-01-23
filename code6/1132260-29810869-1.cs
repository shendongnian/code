    [TestClass()]
    public class WaterContainer
    {        
        [TestMethod()]
        public void WhenWaterContainerIsEmpty_FillingItUp_CausesCorrectWaterLevel() 
        {                                      
            // arrange
            WaterContainer water = new WaterContainer(0);
            // act
            water.FillUpWater();
            // assert
            Assert.AreEqual(5, water.Level);
        }
    }
