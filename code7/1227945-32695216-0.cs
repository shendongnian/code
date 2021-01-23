    //The class to style
    public class SampleTaskItem
        {
            public SampleTaskItem()
            {
                TaskId = (new Random()).Next();
            }
            //Your properties    
            public int TaskId { get; private set; }
    
            //Calculate these with your object's data
            public bool Done { get; set; }
            public bool Late { get; set; }
            public bool IsNew { get; set; }
        }
    
        public class TaskItemStyleConverter : IValueConverter
        {
    
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is SampleTaskItem)
                {
                    var myTask = value as SampleTaskItem;
                    var property = parameter.ToString().ToLower();
    
                    if (property == "fontweight")
                    {
                        return myTask.IsNew ? FontWeights.Bold : FontWeights.Normal;
                    }
                    if (property == "foreground")
                    {
                        return myTask.Late ? Brushes.Red : Brushes.Black;
                    }
                    if (property == "strike")
                    {
                        return myTask.Done ? TextDecorations.Strikethrough : null;
                    }
                    throw new NotImplementedException();
                }
    
                throw new NotImplementedException();
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
