    		public static bool AllPublicPropertiesEqual<T>(T AObj, T BObj, params string[] ignore) where T : class
		{
			if (AObj != null && BObj != null)
			{
				Type type = typeof(T);
				List<string> ignoreList = new List<string>(ignore);
				foreach (PropertyInfo pInfo in type.GetCType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
				{
					if (!ignoreList.Contains(pInfo.Name))
					{
						if (pInfo.PropertyType.IsArray)
						{
							object aElementValues = (type.GetProperty(pInfo.Name).GetValue(AObj, null));
							object bElementValues = (type.GetProperty(pInfo.Name).GetValue(BObj, null));
							if (aElementValues != null && bElementValues != null)
							{
								List<object> AListValues = new List<object>();
								List<object> BListValues = new List<object>();
								foreach (var v in (IEnumerable)aElementValues)
									AListValues.Add(v);
								foreach (var v in (IEnumerable)bElementValues)
									BListValues.Add(v);
								if (AListValues.Count == BListValues.Count)
								{
									object[] aArray = AListValues.ToArray();
									object[] bArray = BListValues.ToArray();
									for (int i = 0; i < aArray.Length; i++)
									{
										if (!AllPublicPropertiesEqual(aArray[i], bArray[i]))
											return false;
									}
								}
								else
									return false;
							}
							else if ((aElementValues == null) != (bElementValues == null))
								return false;
						}
						else if (!pInfo.PropertyType.IsValueType && !pInfo.PropertyType.IsPrimitive && !pInfo.PropertyType.IsEnum && pInfo.PropertyType != typeof(string))
						//else if (Convert.GetTypeCode(pInfo.PropertyType) == TypeCode.Object)
						{
							object AObjectValue = type.GetProperty(pInfo.Name).GetValue(AObj, null);
							object BObjectValue = type.GetProperty(pInfo.Name).GetValue(BObj, null);
							if (!AllPublicPropertiesEqual(BObjectValue, AObjectValue))
								return false;
						}
						else
						{
							object aValue = type.GetProperty(pInfo.Name).GetValue(AObj, null);
							object bValue = type.GetProperty(pInfo.Name).GetValue(BObj, null);
							if (aValue != bValue && (aValue == null || !aValue.Equals(bValue)))
								return false;
						}
					}
				}
				return true;
			}
			return AObj == BObj;
		}
	}
