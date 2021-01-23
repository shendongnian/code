        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var listLegParts = value as ObservableCollection<LegPartAnomaly>;
            if (listLegParts == null || listLegParts.Count == 0)
                return null;
            List<string> convertedList = new List<string>();
            foreach (var legPart in listLegParts)
            {
                foreach (var anomaly in legPart.Anomalies)
                {
                    if(convertedList.Contains(anomaly.Name))
                    {
                        continue;
                    }
                    convertedList.Add(anomaly.Name);
                }
            }
            return convertedList;
        }
