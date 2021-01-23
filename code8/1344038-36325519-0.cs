        private static string Temperature(string temperature)
        {
            try
            {
                string[] value = Regex.Split(temperature, "\n");
                string[] temp = Regex.Split(value[0], "</b> ");
                return temp[1].Substring(0, 2);
            }
            catch { return string.Empty; }
        }
