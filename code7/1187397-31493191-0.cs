    using NUnit.Framework;
    using Ploeh.SemanticComparison;
    using Ploeh.SemanticComparison.Fluent;
    namespace Tests
    {
        [TestFixture]
        class Tests2
        {
            [Test]
            public void ObjectsShuldEqual()
            {
                var flintlockDto = new FlintlockDTO()
                {
                    GName = "name",
                    AdditionalProperty = "whatever",
                    SharedPropertyName = "prop name"
                };
                var flintlock = new Flintlock(flintlockDto);
                Likeness<Flintlock, FlintlockDTO> flintFlockDtoLikeness = flintlock
                    .AsSource().OfLikeness<FlintlockDTO>()
                    .With(dto => dto.GName).EqualsWhen((flintlock1, dto) => flintlock1.GoodName == dto.GName) // you can write an extension method to encapsulate it
                    .Without(dto => dto.AdditionalProperty);
                // assert
                flintFlockDtoLikeness.ShouldEqual(flintlockDto);
            }
        }
        public class FlintlockDTO
        {
            public string GName { get; set; }
            public string SharedPropertyName { get; set; }
            public string AdditionalProperty { get; set; }
        }
        public class Flintlock
        {
            public Flintlock(FlintlockDTO inflator)
            {
                this.GoodName = inflator.GName;
                this.SharedPropertyName = inflator.SharedPropertyName;
            }
            public string GoodName { get; private set; }
            public string SharedPropertyName { get; private set; }
        }
    }
