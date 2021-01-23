        private void call_form_2()
        {
            for (int i = 0; i<10; i++) { 
            Form2 inst_form2 = new Form2();
            inst_form2.MessageReady += MessageReceived;
            inst_form2.ShowDialog();
            }
        }
        private void MessageReceived(string message)
        {
            form1RichTextBox.AppendText(message + Environment.NewLine);
        }
