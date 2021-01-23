        private void b1_Click(object sender, RoutedEventArgs e)
        {
            int count = 10000;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(i.ToString());
            }
            DBG.WriteLine("SBLength: " + sb.Length);
            Clipboard.SetText(sb.ToString());
        }
