    public static class DataControllerTests
    {
        public class WhenViewingWesternRegionLoadLookAhead : SpecificationBase
        {
            private DataController _sut;
            private ViewResult _result;
            private IProvideeDataFeedData _eDataProvider;
            protected override void Given()
            {
                _eDataProvider = A.Fake<IProvideeDataFeedData>();
                A.CallTo(() => _eDataProvider.GetAllDayAheadLoad()).Returns(new collectionActualValueData
                {
                    timestamp = new DateTime(2015, 5, 5),
                    timestampSpecified = true,
                    actualValueData = new[]
                    {
                        new actualValueData {value = 0.1f, name = "Western Region", timestamp = new DateTime(2015, 5, 5)},
                        new actualValueData {value = 0.1f, name = "some region", timestamp = new DateTime(2015, 5, 5)}
                    }
                });
                _sut = new DataController(_eDataProvider);
            }
            protected override void When()
            {
                _result = (ViewResult)_sut.Index();
            }
            [Then]
            public void ViewNameShouldBeCorrect()
            {
                Assert.That(_result.ViewName, Is.EqualTo(""));
            }
            [Then]
            public void ModelShouldBeCorrectType()
            {
                Assert.That(_result.Model.GetType(), Is.EqualTo(typeof(IndexModel)));
            }
            [Then]
            public void GetAllDayAheadLoadShouldBeCalledOnce()
            {
                A.CallTo(() => _eDataProvider.GetAllDayAheadLoad()).MustHaveHappened(Repeated.Exactly.Once);
            }           
        }
        public class WhenViewingWesternRegionLoadLookAheadAndValuesAreUnder50000 : SpecificationBase
        {
            private DataController _sut;
            private ViewResult _result;
            private IndexModel _expectedData;
            private IProvideeDataFeedData _eDataProvider;
            protected override void Given()
            {
                _expectedData = new IndexModel
                {
                    Message = "Everything is cool",
                    Region = "Western Region",
                    Values = new Dictionary<DateTime, float>
                    {
                        {new DateTime(2015, 5, 5), 0.1f}
                    }
                };
                
                _eDataProvider = A.Fake<IProvideeDataFeedData>();
                A.CallTo(() => _eDataProvider.GetAllDayAheadLoad()).Returns(new collectionActualValueData
                {
                    timestamp = new DateTime(2015, 5, 5),
                    timestampSpecified = true,
                    actualValueData = new[]
                    {
                        new actualValueData {value = 0.1f, name = "Western Region", timestamp = new DateTime(2015, 5, 5)},
                        new actualValueData {value = 0.1f, name = "some region", timestamp = new DateTime(2015, 5, 5)}
                    }
                });
                _sut = new DataController(_eDataProvider);
            }
            protected override void When()
            {
               _result = (ViewResult)_sut.Index();
            }
            [Then]
            public void ModelDataShouldBeCorrect()
            {
                var model = (IndexModel)_result.Model;
                Assert.That(model.Message, Is.EqualTo(_expectedData.Message));
                Assert.That(model.Region, Is.EqualTo(_expectedData.Region));
                Assert.That(model.Values, Is.EquivalentTo(_expectedData.Values));
            }
        }
        public class WhenViewingWesternRegionLoadLookAheadAndValuesAreOver50000 : SpecificationBase
        {
            private DataController _sut;
            private ViewResult _result;
            private IndexModel _expectedData;
            private IProvideeDataFeedData _eDataProvider;
            protected override void Given()
            {
                _expectedData = new IndexModel
                {
                    Message = "Heavy Load",
                    Region = "Western Region",
                    Values = new Dictionary<DateTime, float>
                    {
                        {new DateTime(2015, 5, 5), 51000f}
                    }
                };
                _eDataProvider = A.Fake<IProvideeDataFeedData>();
                A.CallTo(() => _eDataProvider.GetAllDayAheadLoad()).Returns(new collectionActualValueData
                {
                    timestamp = new DateTime(2015, 5, 5),
                    timestampSpecified = true,
                    actualValueData = new[]
                    {
                        new actualValueData {value = 51000f, name = "Western Region", timestamp = new DateTime(2015, 5, 5)},
                        new actualValueData {value = 0.1f, name = "some region", timestamp = new DateTime(2015, 5, 5)}
                    }
                });
                _sut = new DataController(_eDataProvider);
            }
            protected override void When()
            {
                _result = (ViewResult)_sut.Index();
            }
            [Then]
            public void ModelDataShouldBeCorrect()
            {
                //Assert.That(_result.Model, Is.EqualTo(_expectedData));
                var model = (IndexModel) _result.Model;
                Assert.That(model.Message, Is.EqualTo(_expectedData.Message));
                Assert.That(model.Region, Is.EqualTo(_expectedData.Region));
                Assert.That(model.Values, Is.EquivalentTo(_expectedData.Values));
                
            }
        }
    }
