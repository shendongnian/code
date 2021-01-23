    public class MeetingTemplateSelector : DataTemplateSelector
        {
            public DataTemplate EquipTemplate { get; set; }
    
            public DataTemplate EventTemplate { get; set; }
    
            public DataTemplate UserTemplate { get; set; }
    
            protected override DataTemplate SelectTemplateCore(object item, 
                      DependencyObject container)
            {
               DataTemplate result;
    
               switch( ((ReportSettingsData) item).SelectedReport)
               {
                    case EquipSummary : result = EquipTemplate; break;
                    case EventSummary : result = EventTemplate; break;
                    case UserSummary ..
               }
    
              return result;
            }
        }
