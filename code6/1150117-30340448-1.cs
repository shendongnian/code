        void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = Convert.ToDateTime(lblTime.Content).AddSeconds(1).ToLongTimeString();
            int btr = sp.BytesToRead;
            if (btr != 0)
            {
                string alarma = char.ConvertFromUtf32(sp.ReadChar());
                Dispatcher.BeginInvoke((Action)(() => 
                    MessageBox.Show("La alarma " + alarma + " se activo", "Alarma",
                        MessageBoxButton.OK, MessageBoxImage.Exclamation)));
            }
        }
