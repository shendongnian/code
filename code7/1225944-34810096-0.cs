public interface IMyAppConfiguration
{
    string Setting1 { get; }
    string Setting2 { get; }
    SomeOtherMoreComplexSetting Setting3 { get; }
}
Then inject this dependency in every class where you require one of the settings and provide one implementation which wraps the current ConfigurationManager class and another implementation which wraps the new configuration model.
This is a perfect example why SOLID design is important and makes code maintenance and innovation easier when done right.
