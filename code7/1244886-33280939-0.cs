    [Serializable]
    public class MyRangeAttribute : LocationContractAttribute,
                                    ILocationValidationAspect<int>,
                                    IInstanceScopedAspect,
                                    IAdviceProvider
    {
        [NonSerialized]
        private object instance;
        [NonSerialized]
        private string maxValueFieldName;
        private int minValue;
        public ILocationBinding maxValueFieldBinding;
        public MyRangeAttribute(int minValue, string maxValueFieldName)
        {
            this.minValue = minValue;
            this.maxValueFieldName = maxValueFieldName;
        }
        public Exception ValidateValue(int value, string locationName, LocationKind locationKind)
        {
            int maxValue = (int) this.maxValueFieldBinding.GetValue(ref this.instance, Arguments.Empty);
            if (value < minValue || value > maxValue)
                return new ArgumentOutOfRangeException(locationName);
            return null;
        }
        public IEnumerable<AdviceInstance> ProvideAdvices(object targetElement)
        {
            FieldInfo maxValueField = ((LocationInfo)targetElement).DeclaringType
                .GetField( this.maxValueFieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance );
            yield return new ImportLocationAdviceInstance(
                typeof (MyRangeAttribute).GetField("maxValueFieldBinding"),
                new LocationInfo(maxValueField));
        }
        public object CreateInstance( AdviceArgs adviceArgs )
        {
            MyRangeAttribute clone = (MyRangeAttribute) this.MemberwiseClone();
            clone.instance = adviceArgs.Instance;
            return clone;
        }
        public void RuntimeInitializeInstance()
        {
        }
    }
