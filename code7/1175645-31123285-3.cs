      public class TemplateSelector : DataTemplateSelector
        {
            public DataTemplate ViewerDataTemplate;
            public DataTemplate ModeratorDataTemplate;
            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                var member = item as Person;
                switch (member.Type)
                {
                    case MemberType.Moderator:
                        return ModeratorDataTemplate;
                    case MemberType.Viewer:
                        return ViewerDataTemplate;
                }
                 
                return null;
            }
        }
