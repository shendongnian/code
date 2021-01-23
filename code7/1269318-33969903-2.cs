    public class TitleValuesDelimitedStringToDisplayStringConverter : IValueConverter
    {
        private string latestValueSendToSource = null;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ciselnik = parameter as Ciselnik;
            var skrDelimitedList = value as string;
            if (string.IsNullOrEmpty(skrDelimitedList))
                return null;
            var skrList = new List<string>();
            Person.ApplyDelimitedString(skrList, skrDelimitedList);
            StringBuilder sb = new StringBuilder();
            foreach (var skr in skrList)
            {
                if (sb.Length > 0)
                    sb.Append(' ');
                sb.Append(ciselnik.FindBySkratka(skr).DisplayName);
            }
            string goingToSendToTarget = sb.ToString();
            if (this.latestValueSendToSource != null && this.latestValueSendToSource.Trim().Equals(goingToSendToTarget)
            {
                return this.latestValueSendToSource;
            }
            else
            {
                return goingToSendToTarget;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            var ciselnik = parameter as Ciselnik;
            var input = value as string;
            this.latestValueSendToSource = input;
            if (string.IsNullOrEmpty(input))
                return Person.CreateDelimitedString(new string[0]);
            
            List<string> skrList = new List<string>();
            foreach (var titul in input.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (ciselnik.ContainsDisplayName(titul))
                    skrList.Add(ciselnik.FindByDisplayName(titul).Skratka);
            }
            return Person.CreateDelimitedString(skrList);
        }
    }
