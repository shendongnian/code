     public class TeamDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultnDataTemplate { get; set; }
        public DataTemplate TeamADataTemplate { get; set; }
        public DataTemplate TeamBDataTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item,
                   DependencyObject container)
        {
            var teamName = (item as Team).Name;
            switch (teamName)
            {
                case "TeamA":
                    return TeamADataTemplate;
                case "TeamB":
                    return TeamBDataTemplate;
                default:
                    return DefaultnDataTemplate;
            }
            
        }
    }
