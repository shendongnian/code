		public static int FlagCount(this System.Enum enumValue){
			var hasFlagAttribute = enumValue.GetType().GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0;
			if (!hasFlagAttribute)
				return 1;
			var count = 0;
			var value = Convert.ToInt32(enumValue);
			while (value != 0){
				if ((value & 1) == 1)
					count++;
				value >>= 1;
			}
			return count;
		}
		public static bool IsSingleFlagCount(this System.Enum enumValue){
			var hasFlagAttribute = enumValue.GetType().GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0;
			if (!hasFlagAttribute)
				return true;
			var isCounted = false;
			var value = Convert.ToInt32(enumValue);
			while (value != 0){
				if ((value & 1) == 1){
					if (isCounted)
						return false;
					isCounted = true;
				}
				value >>= 1;
			}
			return true;
		}
