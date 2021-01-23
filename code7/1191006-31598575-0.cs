       public class MeetingTemplateSelector : DataTemplateSelector
        {
            public DataTemplate AcceptedTemplate { get; set; }
    
            public DataTemplate RejectedTemplate { get; set; }
    
            public DataTemplate PendingTemplate { get; set; }
            protected override DataTemplate SelectTemplateCore(object item, 
                      DependencyObject container)
            {
               DataTemplate result;
               switch( ((MeetingInvitee) item).Status)
               {
                    case "Accepted" : result = AcceptedTemplate; break;
                    case "Rejected" : result = RejectedTemplate; break;
                    case "Pending"  : result = PendingTemplate; break;
               }
              return result;
            }
        }
