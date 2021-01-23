    [PSerializable]
    public class MyValidationAspect : LocationInterceptionAspect, IAdviceProvider, IInstanceScopedAspect, IAspectProvider
    {
        private string otherPropertyName;
        public ILocationBinding MyPropertyBinding;
        public ILocationBinding OtherPropertyBinding;
        private bool provideOther;
        public MyValidationAspect(string otherPropertyName, bool provideOther = true)
        {
            this.otherPropertyName = otherPropertyName;
            this.provideOther = provideOther;
        }
        public IEnumerable<AdviceInstance> ProvideAdvices(object targetElement)
        {
            FieldInfo otherBindingField = typeof(MyValidationAspect).GetField("OtherPropertyBinding");
            PropertyInfo otherProperty = ((LocationInfo) targetElement).DeclaringType.GetProperty( this.otherPropertyName );
            yield return new ImportLocationAdviceInstance(otherBindingField, new LocationInfo(otherProperty));
            FieldInfo myBindingField = typeof(MyValidationAspect).GetField("MyPropertyBinding");
            yield return new ImportLocationAdviceInstance(myBindingField, (LocationInfo)targetElement);
        }
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            if ( this.provideOther )
            {
                PropertyInfo otherProperty = ((LocationInfo) targetElement).DeclaringType.GetProperty( this.otherPropertyName );
                yield return new AspectInstance( otherProperty, new MyValidationAspect( ((LocationInfo) targetElement).Name, false ) );
            }
        }
        public override void OnSetValue( LocationInterceptionArgs args )
        {
            object instance = args.Instance;
            int newValue = (int)args.Value;
            int otherValue = (int)this.OtherPropertyBinding.GetValue(ref instance, Arguments.Empty);
            // perform the check
            if (newValue == otherValue)
                throw new ArgumentException();
            else
                args.ProceedSetValue();
        }
        public object CreateInstance( AdviceArgs adviceArgs )
        {
            return new MyValidationAspect( this.otherPropertyName );
        }
        public void RuntimeInitializeInstance()
        {
        }
    }
