    public static class StoryboardHelper
    {
        public static readonly DependencyProperty CompletedCommandProperty = DependencyProperty.RegisterAttached("CompletedCommand", typeof(ICommand), typeof(StoryboardHelper), new PropertyMetadata(null, OnCompletedCommandChanged));
        public static readonly DependencyProperty CompletedCommandParameterProperty = DependencyProperty.RegisterAttached("CompletedCommandParameter", typeof(object), typeof(StoryboardHelper), new PropertyMetadata(null));
        public static void SetCompletedCommand(DependencyObject o, ICommand value)
        {
            o.SetValue(CompletedCommandProperty, value);
        }
        public static ICommand GetCompletedCommand(DependencyObject o)
        {
            return (ICommand)o.GetValue(CompletedCommandProperty);
        }
        public static void SetCompletedCommandParameter(DependencyObject o, object value)
        {
            o.SetValue(CompletedCommandParameterProperty, value);
        }
        public static object GetCompletedCommandParameter(DependencyObject o)
        {
            return o.GetValue(CompletedCommandParameterProperty);
        }
        private static void OnCompletedCommandChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var sb = sender as Storyboard;
            
            if(sb != null)
            {
                sb.Completed += (a, b) =>
                {
                    var command = GetCompletedCommand(sb);
                    if (command != null)
                    {
                        if (command.CanExecute(GetCompletedCommandParameter(sb)))
                        {
                            command.Execute(GetCompletedCommandParameter(sb));
                        }
                    }
                };
            }
        }
    }
