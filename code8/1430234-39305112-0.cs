    public class MyPage : Page
    {
          public static readonly DependencyProperty HeaderTemplateProperty =
             DependencyProperty.Register(nameof(HeaderTemplate), 
             typeof(UIElement), typeof(MyPage), new PropertyMetadata(null));
    
          public UIElement HeaderTemplate
          {
              get
              {
                  return (UIElement)GetValue(HeaderTemplateProperty);
              }
              set
              {
                  SetValue(HeaderTemplateProperty, value);
              }
          }
    }
