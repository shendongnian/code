    public class EquipmentTemplateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch ((int)value)
            {
                case 0:
                    var a = Application.Current.Resources.FirstOrDefault(r => r.Key.ToString() == "EquipmentNormalTemplate");
                    return a.Value;
    
                case 1:
                    var b = Application.Current.Resources.FirstOrDefault(r => r.Key.ToString() == "EquipmentUpgradeTemplate");
                    return b.Value;
    
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
