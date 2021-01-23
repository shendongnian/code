    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BowlingKataTDD;
    
    namespace BowlingKataTDDTest
    {
        [TestClass]
        public class BowlingKataTDDUnitTests 
        {
            [TestMethod]
            public void DoesGameExist()
            {
                //arrange
                BowlingKataTDD.Game game = new BowlingKataTDD.Game();
            }
        }
    }
