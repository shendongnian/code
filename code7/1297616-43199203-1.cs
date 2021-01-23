    public VariantValue GetTagValue(string tagName)
		{
			GlobalDataItem normalTag = (GlobalDataItem)Globals.Tags.GlobalDataItems.FirstOrDefault(p => p.Name == tagName);
			if (normalTag != null)
			{
				return normalTag.Value;
			}
			LightweightTag lightTag = (LightweightTag)Globals.Tags.LightweightTags.FirstOrDefault(p => p.Name == tagName);
			if (lightTag  != null)
			{
				return lightTag.Value;
			}
			return null;
		}
