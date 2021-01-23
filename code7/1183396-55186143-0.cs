    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Forms.Integration;
    using System.Windows.Media;
    public class MyElementHost : ElementHost
    {
       public MyElementHost()
        {
            this.HostContainer.Loaded += new RoutedEventHandler(HostPanelLoad);
        }
    
        public void HostPanelLoad(object sender, RoutedEventArgs e)
        {
            System.Drawing.Color parentColor = this.Parent.BackColor;
            this.HostContainer.Background = new SolidColorBrush(Color.FromArgb(parentColor.A, parentColor.R, parentColor.G, parentColor.B));
        }
    }
