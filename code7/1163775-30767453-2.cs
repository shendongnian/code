	public static class EnumHelper
	{
		public static bool TryParse<TEnum>(string nameOrSynonym, out TEnum enumValue)where TEnum : struct
		{
			enumValue = default (TEnum);
			bool success = false;
			TEnum result;
			
            // First of all, this is the first attemp to parse the enum
            // value using regular Enum.TryParse. If it succeeds, it will mean
            // that passed enum value name is already in the enumeration. 
			if (!Enum.TryParse<TEnum>(nameOrSynonym, true, out result))
			{
				nameOrSynonym = nameOrSynonym.ToLowerInvariant();
				
                // If we need to look for a synonym of passed enumeration value
                // name, then we need reflection to look for static fields
                // in the given enumeration type. Enumeration values are just
                // static fields.
                // The SingleOrDefault part will look for fields with 
                // SynonymAttribute and it will extract the one with the
                // synonym which equals the passed enumeration value name!
				FieldInfo enumValueField = typeof (TEnum).GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField)
														.SingleOrDefault
														(
															field => field.GetCustomAttribute<SynonymAttribute>() != null 
																	&& field.GetCustomAttribute<SynonymAttribute>().Name.ToLowerInvariant() == nameOrSynonym
														);
				
				
				
                // If the synonym was found, then we get the field value
                // and we set it to the result enum value!
				if (enumValueField != null)
				{
					enumValue = (TEnum)enumValueField.GetValue(null);
					success = true;
				}
			}
			else
			{
				enumValue = result;
				success = true;
			}
			return success;
		}
	}
