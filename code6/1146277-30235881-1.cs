    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Printing;
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
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new ViewModel();
            }
        }
    
        public class ViewModel
        {
            public ObservableCollection<PrinterWrapper> Printers { get; set; }
    
            public ViewModel()
            {
                this.Printers = new ObservableCollection<PrinterWrapper>();
    
                LocalPrintServer server = new LocalPrintServer();
                var printQueues = server.GetPrintQueues(new EnumeratedPrintQueueTypes[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
                foreach (var printQueue in printQueues)
                {
                    var printerWrapper = new PrinterWrapper();
                    printerWrapper.PrinterName = printQueue.Name;
                    printerWrapper.IsDefaultPrinter = (printQueue.Name == server.DefaultPrintQueue.Name);
    
                    this.Printers.Add(printerWrapper);
                }
            }
        }
        public class PrinterWrapper
        {
            public string PrinterName { get; set; }
            public bool IsDefaultPrinter { get; set; }
        }
    }
