    using System;
    using System.Windows;
    
    namespace Messaging
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                MessageStorage.Messages = new System.Collections.ObjectModel.ObservableCollection<Message>();
            }
    
            private void btnSubmit_Click(object sender, RoutedEventArgs e)
            {
                Message message = new Message();
                message.MessageContent = txtMessage.Text;
                message.PublishDate = DateTime.Now;
    
                MessageStorage.Messages.Add(message);
    
                MessageDialog messageDialog = new MessageDialog(MessageStorage.Messages);
                messageDialog.ShowDialog();
            }
        }
    }
