    public class MyControl : ContentControl
    {
         public MyControl()
         {
             DefaultStyleKey = typeof(MyControl);
         }
         public override void OnApplyTemplate()
         {
             base.OnApplyTemplate();
             var template = this.pion_test.Template;
             var contour = GetTemplateChild("contour_forme");
             forme_path = template.FindName("contour_forme", this.pion_test) as Path;
             Path path = FindVisualChild<Path>(this.pion_test);
             var test = this.pion_test.FindName("contour_forme");
             var test2 = this.pion_test.Template.FindName("contour_forme", this.pion_test);
         }
    }
