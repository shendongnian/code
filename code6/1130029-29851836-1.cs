        private Aroon _target;
        [TestInitialize]
        public void TestInit()
        {
            _target=new Aroon(5)
            {
                OhlcList = new List<OhlcSample>
                {
                    new OhlcSample(166.90, 163.65),
                    new OhlcSample(165.00, 163.12),
                    new OhlcSample(165.91, 163.21),
                    new OhlcSample(167.29, 165.11),
                    new OhlcSample(169.99, 166.84),
                    new OhlcSample(170.92, 167.90),
                    new OhlcSample(168.47, 165.90),
                    new OhlcSample(167.75, 165.75),
                    new OhlcSample(166.14, 161.89),
                    new OhlcSample(164.77, 161.44),
                    new OhlcSample(163.19, 161.49),
                    new OhlcSample(162.50, 160.95),
                    new OhlcSample(163.25, 158.84),
                    new OhlcSample(159.20, 157.00),
                    new OhlcSample(159.33, 156.14),
                    new OhlcSample(160.00, 157.00),
                    new OhlcSample(159.35, 158.07),
                    new OhlcSample(160.70, 158.55),
                    new OhlcSample(160.90, 157.66),
                    new OhlcSample(164.38, 158.45),
                    new OhlcSample(167.75, 165.70),
                    new OhlcSample(168.93, 165.60),
                    new OhlcSample(165.73, 164.00),
                    new OhlcSample(167.00, 164.66),
                    new OhlcSample(169.35, 165.01),
                    new OhlcSample(168.12, 164.65),
                    new OhlcSample(168.89, 165.79),
                    new OhlcSample(168.65, 165.57),
                    new OhlcSample(170.85, 166.00),
                    new OhlcSample(171.61, 169.10)
                }
            };
        }
        [TestMethod]
        public void JustToHelpYou()
        {
            var result = _target.Calculate();
            var expectedUp = new List<double>()
            {
                100,80,60,40,20,0,0,0, 0,0,40,20,0,100,100,100,100,80, 60,100,80,60,40,100,100
            };
            var expectedDown = new List<double>
            {
                20,0,0,100,100,80,100,100,100,100,80,60,40,20,0,0,40,20,0,0,40,20,0,40,20
            };
            Assert.IsTrue( result.Up.SequenceEqual(expectedUp));
            Assert.IsTrue( result.Down.SequenceEqual(expectedDown));
        }
