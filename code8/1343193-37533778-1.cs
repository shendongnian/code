    public class LocalizedDisplayMetadataProvider : IDisplayMetadataProvider
	{
		public String Translate(String key)
		{
			if(key != null && key.StartsWith("#"))
			{
				return key.TrimStart('#').ToUpper(); // Todo: Replace with real localization code (e.g. fetch from json)...
			}
			else
			{
				return key;
			}
		}
		public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
		{
			foreach(var attr in context.Attributes.OfType<DisplayAttribute>().Where(a => a.ResourceType == null))
			{
				attr.Name = this.Translate(attr.Name);
				attr.Description = this.Translate(attr.Description);
				attr.GroupName = this.Translate(attr.GroupName);
				attr.Prompt = this.Translate(attr.Prompt);
				attr.ShortName = this.Translate(attr.ShortName);
			}
		}
	}
