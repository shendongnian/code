    public partial class App : Application
    {
        public static void ReportClick(FrameworkElement frameworkElement)
        {
            MessageBox.Show(
                "Sender name: \"" + frameworkElement.Name + "\"\n" +
                "Sender column: " + Grid.GetColumn(frameworkElement));
        }
    }
