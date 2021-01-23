    public class HighlightNames : IValueConverter
            {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                               var personName = ((Person)value).PersonName;
        
                    var textBlock = new TextBlock();
                    textBlock.TextWrapping = TextWrapping.Wrap;
        
                    // Add logic to split the string into multiple string to split based on string to highlight. For ex in Mahesh Nagar, ar should be highlighted so string would split into two 1) Mahesh Nag 2) ar
                    var firstPart = personeName.Substring(0, personeName.IndexOf("ar"));
                    var secondPart = personeName.Substring(personeName.IndexOf("ar"), personName.Length);
        
                    textBlock.Inlines.Add(new Run(firstPart));
                    Run run = new RunsecondPart);
                    run.Background = Brushes.Aqua;;
                    textBlock.Inlines.Add(run );
                     return textBlock;
                }
        
                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    throw new NotImplementedException();
                }
            }
