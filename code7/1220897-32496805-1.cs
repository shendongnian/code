    public class NodaTimeFixingBodyModelValidator : DefaultBodyModelValidator {
        public override bool ShouldValidateType(Type type) {
            return type != typeof(LocalTime) // you may want to exclude other noda types here
                && base.ShouldValidateType(type);
        }
    }
    ...
    var config = new HttpConfiguration();                        
    config.Services.Replace(typeof(IBodyModelValidator), new NodaTimeFixingBodyModelValidator());
    ...
