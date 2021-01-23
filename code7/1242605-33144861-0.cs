    [SitecoreType(AutoMap =true)]
    public class Widget
    {
         ....
         [SitecoreField(FieldType =SitecoreFieldType.TreelistEx)]
         public virtual IEnumerable<WidgetButton> Buttons { get; set; }
    }
