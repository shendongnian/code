    private static Decimal GetEnumCustomAttribute(this Enum leEnum, Typ typ)
        {
            try
            {
                if (leEnum == null) throw new ArgumentNullException("leEnum");
                Type type = leEnum.GetType();
                MemberInfo[] memInfo = type.GetMember(leEnum.ToString());
                if (memInfo != null && memInfo.Length > 0)
                {
                    object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumValue), false);
                    if (attrs != null && attrs.Length > 0)
                        return ((EnumValue)attrs[0]).Value;
                }
                return Decimal.MinValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
