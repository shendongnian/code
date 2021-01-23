    using System;
    using NUnit.Framework;
    using AutoMapper;
    
    namespace MyTests {
        [TestFixture]
        public class AutomappingTests {
    
            public class IncrementalPOCO
            {
                public int ValueType { get; set; }
                public string RefernceType { get; set; }
            }
    
            private Func<IncrementalPOCO> getOriginal = () => new IncrementalPOCO()
            {
                ValueType = 123,
                RefernceType = "original text"
            };
    
            private IncrementalPOCO updateValue = new IncrementalPOCO()
            {
                ValueType = 456
            };
    
            private IncrementalPOCO updateText = new IncrementalPOCO()
            {
                RefernceType = "updated text"
            };
    
            private IncrementalPOCO updateWithDefault = new IncrementalPOCO()
            {
                ValueType = 0,
                RefernceType = null
            };
    
    
            public static bool Always(object value)
            {
                return true;
            }
    
            public static bool IsDefault(Type type, object value) {
                if (type.IsValueType) {
                    return Activator.CreateInstance(type).Equals(value);
                }
                return null == value;
            }
    
            public static bool AreDifferent(Type type, object source, object destination) {
                if (type.IsValueType) {
                    return !source.Equals(destination);
                }
                return !ReferenceEquals(source, destination);
            }
    
            [Test]
            public void CouldUpdateValues() {
                // Updates all properties
                var original = getOriginal();
                var map = Mapper.CreateMap<IncrementalPOCO, IncrementalPOCO>();
                
                map.ForAllMembers(opt => opt.Condition(srs => Always(srs.SourceValue))); // just for overload resolution, `true` doesn't work
    
                Mapper.Map<IncrementalPOCO, IncrementalPOCO>(updateValue, original);
                Assert.AreEqual(null, original.RefernceType);
                Assert.AreEqual(updateValue.ValueType, original.ValueType);
    
            }
    
            [Test]
            public void CouldUpdateNonDefaultValues()
            {
                // should work for value types and reference types (nulls)
                var original = getOriginal();
                var map = Mapper.CreateMap<IncrementalPOCO, IncrementalPOCO>();
                // NB != or simple equility won't work
                map.ForAllMembers(opt => opt.Condition(srs => !(IsDefault(srs.SourceType, srs.SourceValue))) );
                
                Mapper.Map<IncrementalPOCO, IncrementalPOCO>(updateValue, original);
                Assert.AreEqual("original text", original.RefernceType);
                Assert.AreEqual(updateValue.ValueType, original.ValueType);
    
                original = getOriginal();
                Mapper.Map<IncrementalPOCO, IncrementalPOCO>(updateText, original);
                Assert.AreEqual("updated text", original.RefernceType);
                Assert.AreEqual(123, original.ValueType);
    
                // this mapping should not change the original because all new values are default
                original = getOriginal();
                Mapper.Map<IncrementalPOCO, IncrementalPOCO>(updateWithDefault, original);
                Assert.AreEqual("original text", original.RefernceType);
                Assert.AreEqual(123, original.ValueType);
            }
    
            [Test]
            public void CouldUpdateChangedValues() {
                // should update value types when new value is a default one, but different from origin
                var original = getOriginal();
                var map = Mapper.CreateMap<IncrementalPOCO, IncrementalPOCO>();
                // NB != or simple equility won't work
                map.ForAllMembers(opt => opt.Condition(srs => (AreDifferent(srs.SourceType, srs.SourceValue, srs.DestinationValue))));
    
                Mapper.Map<IncrementalPOCO, IncrementalPOCO>(updateValue, original);
                Assert.AreEqual(null, original.RefernceType);
                Assert.AreEqual(updateValue.ValueType, original.ValueType);
    
                original = getOriginal();
                Mapper.Map<IncrementalPOCO, IncrementalPOCO>(updateText, original);
                Assert.AreEqual("updated text", original.RefernceType);
                Assert.AreEqual(0, original.ValueType);
    
                // this mapping will change the original because all new values are default but different from original
                original = getOriginal();
                Mapper.Map<IncrementalPOCO, IncrementalPOCO>(updateWithDefault, original);
                Assert.AreEqual(null, original.RefernceType);
                Assert.AreEqual(0, original.ValueType);
            }
    
        }
    }
