    public class StringToContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var question = (string)value;
            if (string.IsNullOrWhiteSpace(question))
            {
                return Binding.DoNothing;
            }
            //Splitting question in each place where '?' char occurs
            var questionSplit = question.Split('?');
            var panel = GetPanel();
            for (int i = 0; i < questionSplit.Length; i++)
            {
                //Add current part of the Question
                panel.Children.Add(GetTextBlock(questionSplit[i]));
                //If there's next part of your question black border is added to panel
                //That's usefull if you want to have more than one questionmark in your question
                if (i < questionSplit.Length - 1)
                {
                    panel.Children.Add(GetBorder());
                }
            }
            return panel;
        }
        private Panel GetPanel()
        {
            var panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            return panel;
        }
        private TextBlock GetTextBlock(string text)
        {
            var textBlock = new TextBlock();
            textBlock.Text = text;
            return textBlock;
        }
        private Border GetBorder()
        {
            var border = new Border();
            var style = Application.Current.Resources["CustomBorderStyle"] as Style;
            border.Style = style;
            return border;
        }
        //Most likely you won't need converting back since you've got your question on the view model
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
