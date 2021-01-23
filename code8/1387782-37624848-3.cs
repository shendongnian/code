    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    
    namespace Messaging
    {
        /// <summary>
        /// Interaction logic for MessageDialog.xaml
        /// </summary>
        public partial class MessageDialog : Window
        {
            public MessageDialog(ObservableCollection<Message> messages)
            {
                InitializeComponent();
                lvMessages.ItemsSource = messages.OrderByDescending(m => m.PublishDate);
            }
        }
    }
