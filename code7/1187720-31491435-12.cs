    public interface ILocalizerFactory 
    {
        ILocalizer Create(ResourceDictionary appResDic, string projectName);
    }
    public class ILocalizerFactory
    {
        public ILocalizer Create(ResourceDictionary appResDic, string projectName)
        {
            var localizer = new Localizer(appResDic, projectName, "Languages",  "Language", "en");
            return localizer;
        }
    }
