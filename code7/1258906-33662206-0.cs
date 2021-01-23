        private const string rootPath = @"C:\Temp\";
        private static void WriteFile<T>(List<T> selectedList)
        {
            var props = typeof(T).GetProperties();
            var sb = new StringBuilder();
            foreach (var item in selectedList) {
                foreach (var prop in props) {
                    var val = prop.GetValue(item);
                    sb.Append(val);
                    sb.Append(";");
                }
            }
            sb.AppendLine();
            var fileName = string.Format("{0}{1}.txt", rootPath, typeof (T).Name);
            File.WriteAllText(fileName, sb.ToString());
        }
