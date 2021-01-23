    public partial class FrameworkElement
    {
        internal virtual string GetPlainText()
        {
            return null;
        }
    }
    public class Control : FrameworkElement
    {
        public override string ToString()
        {
            string plainText = null;
     
            if (CheckAccess())
            {
                plainText = GetPlainText();
            }
            else
            {
                plainText = (string)Dispatcher.Invoke(DispatcherPriority.Send, new TimeSpan(0, 0, 0, 0, 20), new DispatcherOperationCallback(delegate(object o) {
                        return GetPlainText();
                    }), null);
            }
     
            if (!String.IsNullOrEmpty(plainText))
            {
                return SR.Get(SRID.ToStringFormatString_Control, base.ToString(), plainText);
            }
     
            return base.ToString();
        }
    }
    public class ContentControl : Control
    {
        internal override string GetPlainText()
        {
            return ContentObjectToString(Content);
        }
 
        internal static string ContentObjectToString(object content)
        {
            if (content != null)
            {
                FrameworkElement feContent = content as FrameworkElement;
                if (feContent != null)
                {
                    return feContent.GetPlainText();
                }
 
                return content.ToString();
            }
 
            return String.Empty;
        }
    }
    public class ListBoxItem : ContentControl { }
    public class ComboBoxItem : ListBoxItem { }
