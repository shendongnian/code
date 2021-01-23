    public class IronStageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate IronStage1Template { get; set; }
        public DataTemplate IronStage2Template { get; set; }
        public object IronStage1Selector { get; set; }
        public object IronStage2Selector { get; set; }
        public override DataTemplate SelectTemplate(object selector,
          DependencyObject container)
        {
            if(selector == this.IronStage1Selector)
            {
                return IronStage1Template;
            }
            return IronStage2Template;
        }
    }
