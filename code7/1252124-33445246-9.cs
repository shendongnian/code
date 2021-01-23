    public partial class App : Application
    {
        public static void ReportClick(
            FrameworkElement frameworkElement, [CallerMemberName]string callerName = null)
        {
            MessageBox.Show(
                "Caller name: \"" + callerName + "\"\n" +
                "Sender name: \"" + frameworkElement.Name + "\"\n" +
                "Sender column: " + Grid.GetColumn(frameworkElement));
        }
    }
