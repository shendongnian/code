    public class ConfigurationExtensions
	{
		public static Dictionary<string, string> ToDictionary(this IConfiguration config, bool stripSectionPath = true)
        {
            var data = new Dictionary<string, string>();
            var section = stripSectionPath ? config as IConfigurationSection : null;
            ConvertToDictionary(config, data, section);
            return data;
        }
        static void ConvertToDictionary(IConfiguration config, Dictionary<string, string> data = null, IConfigurationSection top = null)
        {
            if (data == null) data = new Dictionary<string, string>();
            var children = config.GetChildren();
            foreach (var child in children)
            {
                if (child.Value == null)
                {
                    ConvertToDictionary(config.GetSection(child.Key), data);
                    continue;
                }
                var key = top != null ? child.Path.Substring(top.Path.Length + 1) : child.Path;
                data[key] = child.Value;
            }
        }
	}
