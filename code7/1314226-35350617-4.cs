        public static List<string> DeQualifyFieldName(string targetField, Type targetType)
        {
            var r = targetField.Split('.').ToList();
            foreach (var p in targetType.Name.Split('.'))
                if (r.First() == p) r.RemoveAt(0);
            return r;
        }
