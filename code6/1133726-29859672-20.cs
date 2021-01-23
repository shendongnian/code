    public class RegHelper
    {
        private static readonly RegistryKey Root = Registry.CurrentUser
            .CreateSubKey(System.AppDomain.CurrentDomain.FriendlyName);
        private readonly RegistryKey _thisKey = Root;
        public RegHelper() { }
        public RegHelper(string favoriteKey)
        {
            _thisKey = Root.CreateSubKey(favoriteKey);
        }
        public List<string> GetSubKeys()
        {
            return _thisKey.GetSubKeyNames().ToList();
        }
        public void SetProperty(string propertyName, string value)
        {
            _thisKey.SetValue(propertyName, value, RegistryValueKind.String);
        }
        public void SetProperty(string propertyName, bool value)
        {
            SetProperty(propertyName, value.ToString());
        }
        public string GetProperty(string propertyName)
        {
            return GetProperty(propertyName, string.Empty);
        }
        public string GetProperty(string propertyName, string defaultValue)
        {
            return _thisKey.GetValue(propertyName, defaultValue).ToString();
        }
        public bool GetPropertyAsBool(string propertyName)
        {
            return bool.Parse(GetProperty(propertyName, default(bool).ToString()));
        }
    }
