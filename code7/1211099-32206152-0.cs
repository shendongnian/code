    public static class EnumViewConverter<T> where T : struct
    {
        public static List<EnumView> ConvertToView()
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");
            List<EnumView> enumViews = new List<EnumView>();
            T[] enumValues = (T[])Enum.GetValues(typeof(T));
            
            foreach (var enumValue in enumValues)
            {
                var enumView = new EnumView
                {
                    Id = Convert.ToInt32(enumValue),
                    Name = Enum.GetName(typeof(T), enumValue)
                };
                enumViews.Add(enumView);
            }
            return enumViews;
        }
    }
