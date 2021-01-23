      public class QuiztemplateSelector : DataTemplateSelector
      {
        public DataTemplate TrueOrFalseTemplate { get; set; }
        public DataTemplate MultiAnswerTemplate { get; set; }
        public DataTemplate MultiChoiceTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
          var question = item as QuizQuestion;
          if (question.Type.Equals("TruOrFalse"))
            return TrueOrFalseTemplate;
          else if (question.Type.Equals("MultiAnswer"))
            return MultiAnswerTemplate;
          else if ("MultiChoice")
            return MultiChoiceTemplate;
    
          return null; //Or your default Template.
        }
      }
