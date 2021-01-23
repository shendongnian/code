        private async void buttonTxSend_Click(object sender, RoutedEventArgs e)
        {
            buttonTxSend.IsEnabled = false;
            string _fileText = textBoxTx.Text;
            var _sendTask = Task.Factory.StartNew(() => SendFile(_fileText));
            await _sendTask;
            buttonTxSend.IsEnabled = true;
        }
        private void SendFile(string _fileText)
        {
            var _fileLenght = _fileText.Length;
            this.Dispatcher.Invoke(() => { progressBarTx.Maximum = _fileLenght - 1; });
            this.Dispatcher.Invoke(() => { progressBarTx.Value = 0; });
            for (int i = 0; i < _fileLenght; i++)
            {
                this.Dispatcher.Invoke(() => { progressBarTx.Value = i; });
                string _character = _fileText[i].ToString();
                if (_lfTxFlag || _character != "\n")
                {
                    try
                    {
                        _comPort.Write(_character);
                        Console.WriteLine(_character);
                    }
                    catch (Exception _ex)
                    {
                        Message.Error("Error Write Data: " + _ex.ToString());
                        StatusRed("Error");
                        break;
                    }
                }
            }
        }
