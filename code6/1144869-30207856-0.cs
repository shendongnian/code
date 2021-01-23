    Messenger.Default.Register<DialogMessage>(this, ProcessMessage);
        private static void ProcessMessage(DialogMessage message)
        {
            var result = MessageBox.Show(
                            message.Content,
                            message.Caption,
                            message.Button);
            message.Callback(result);
        }
