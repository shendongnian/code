        public string GetResults(
            string code = "",
            string id = "",
            DateTime? registerDate = null,
            IEnumerable<Category> type = null,
            int pageNum = 1,
            bool all = false)
        {
            var result = "results/?";
            var firstFound = false;    //Used for add & to string
            for (int i = 0; i < 6; i++)
            {
                var partial = string.Empty;
                switch (i)
                {
                    case 0:
                        partial = GetIfNotEmpty("code", code);
                        break;
                    case 1:
                        partial = GetIfNotEmpty("id", id);
                        break;
                    case 2:
                        partial = GetIfNotEmpty("registerDate", registerDate);
                        break;
                    case 3:
                        partial = GetIfNotEmpty("type", type);
                        break;
                    case 4:
                        partial = GetIfNotEmpty("pageNum", pageNum);
                        break;
                    default:
                        partial = GetIfNotEmpty("all", all);
                        break;
                }
                if (string.IsNullOrWhiteSpace(partial))
                    continue;
                if (firstFound)
                    result += "&";
                else
                    firstFound = true;
                result += partial;
            }
            return result;
        }
        private string GetIfNotEmpty<T>(string name, T value)
        {
            if (value == null)
                return string.Empty;
            if (value is IEnumerable)
            {
                var enumerableFinalString = string.Empty;
                foreach (var item in ((IEnumerable)value))
                {
                    enumerableFinalString += item.ToString();
                }
                return string.Format("{0}={1}", name, enumerableFinalString);
            }
            return string.Format("{0}={1}", name, value.ToString());
        }
