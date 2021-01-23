   		public static void Map (object objFrom, object objTo, StringComparison comparisionType = StringComparison.InvariantCulture)
        {
            if (objFrom != null && objTo != null)
            {
                PropertyInfo[] propTo = objTo.GetType().GetProperties( /*Optional binding flag to get private property use field instead to get each field not only properties*/ );
                foreach (PropertyInfo prop in objFrom.GetType().GetProperties( /*Optional binding flag to get private property use field instead to get each field not only properties*/) )
                {
					if ( !prop.CanRead )
						continue;
						
                    try
                    {
                        object valFrom = objFrom.GetType().InvokeMember(prop.Name, BindingFlags.GetProperty /*as before play with binding flag here*/, null, objFrom, null);
                        PropertyInfo target = propTo.FirstOrDefault(x => x.Name.Equals(prop.Name, comparisionType));
						if ( target == null || !target.CanWrite )
							continue;
                        if (target.PropertyType.IsGenericType && target.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
							if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
							{
								if (prop.PropertyType.Equals(target.PropertyType))
									objTo.GetType().InvokeMember(target.Name, BindingFlags.SetProperty, null, objTo, new object[1] { valFrom });
							}
							else
							{
								if (prop.PropertyType.Equals(Nullable.GetUnderlyingType(target.PropertyType)))
									objTo.GetType().InvokeMember(target.Name, BindingFlags.SetProperty , null, objTo, new object[1] { valFrom });
							}
                        }
                        else
                        {
							if (prop.PropertyType.Equals(target.PropertyType))
								objTo.GetType().InvokeMember(target.Name, BindingFlags.SetProperty, null, objTo, new object[1] { valFrom });
                        }
                    }
                    catch { }
                }
            }
        }
