    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace GlobalTime_ELITE_for_WPF
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            TimeCitiesDialog tcDialog = new TimeCitiesDialog();
            LatAndLongDialog lalDialog = new LatAndLongDialog();
    
            public MainWindow()
            {
                InitializeComponent();
    
    
                UserDescText.Content = "Select a TimeCity or enter the latitude and longitude in \n" +
                                     "to view the World Time there. Or, select another one of the\n" +
                                     "options below to do that. Go to Help by clicking on the link\n" +
                                     "on the upper-right corner of the window to view everything you\n" +
                                     "can do.";
                this.Closed += CloseOff;
            }
    
            private void OpenTimeCitiesDialog(Object Sender, EventArgs E)
            {
                
                tcDialog.Show();
            }
    
            private void OpenLatAndLongDialog(Object Sender, EventArgs E)
            {
                
                lalDialog.Show();
            }
    
            private void CloseOff(Object Sender, EventArgs E)
            {
                // Close the dialogs first, then allow this method
                // to end which will finish the this.Close() process.
                tcDialog.Close();
                lalDialog.Close();
            }
        }
    }
