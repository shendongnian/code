    public class HighlightNames : IValueConverter
            {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                               var personName = ((Person)value).PersonName;
        
                    var textBlock = new TextBlock();
                    textBlock.TextWrapping = TextWrapping.Wrap;
        
                    // Add logic to split the string into multiple string to split based on string to highlight. For ex in Mahesh Nagar, ar should be highlighted so string would split into two 1) Mahesh Nag 2) ar
		string toSearch = "ar";
		var regex = new Regex(toSearch);
		
		int currentIndex = 0;
		var matches = regex.Matches(inputString);
		for (int index = 0; index < matches.Count; index++)
		{
			Match match = matches[index];
            if (match.Index == 0)
            {
                    Run run = new Run(personName.Substring(0, toSearch.Length));
                    run.Background = Brushes.Aqua;;
                    textBlock.Inlines.Add(run);
            }
			else
			{
                               textBlock.Inlines.Add(new Run(personName.Substring(currentIndex, match.Index - currentIndex))); 				               
                    Run run = new Run(personName.Substring(match.Index, toSearch.Length)
                    run.Background = Brushes.Aqua;;
                    textBlock.Inlines.Add(run);
				
			}
					}
		
		if (currentIndex < inputString.Length)
		{
                     textBlock.Inlines.Add(new Run(personName.Substring(currentIndex, inputString.Length - currentIndex))); 
		}
                     return textBlock;
                }
        
                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    throw new NotImplementedException();
                }
            }
