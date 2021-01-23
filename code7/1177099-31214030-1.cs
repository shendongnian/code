    class MySumConverter:IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double sum = 0.0;
            
            var lPosContainer = (ReadOnlyObservableCollection<Object>)values[1];
            
            if (lPosContainer[0] != null && lPosContainer[0] is CollectionViewGroup)
            {
                foreach (CollectionViewGroup group in lPosContainer)
                {
                    sum += sumPositions((ReadOnlyObservableCollection<Object>)group.Items);
                }
            }
            else
            {
                sum += sumPositions(lPosContainer);
            }
            return sum;
        }
        private double sumPositions(ReadOnlyObservableCollection<Object> items)
        {
            double sum = 0.0;
            foreach (LPosition lPos in items)
            {
                sum += lPos.GB;
            }
            return sum;
        }
