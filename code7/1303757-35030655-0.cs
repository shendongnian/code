            private static OpenFileDialog OpenFile()
            {
                OpenFileDialog ofd;
                ofd = new OpenFileDialog();
                ofd.AddExtension = true;
                ofd.DefaultExt = "*.*";
                ofd.Filter = "media (*.*)|*.*";
                ofd.ShowDialog();
                return ofd;
            }
    
            private void loadm1_Click(object sender, RoutedEventArgs e)
            {
                OpenFileDialog ofd = OpenFile();
                M1.Source = new Uri(ofd.FileName, UriKind.Relative);
                M1.Position = TimeSpan.Zero;
                M1.LoadedBehavior = MediaState.Stop;
            }
    
            private void loadm2_Click(object sender, RoutedEventArgs e)
            {
                OpenFileDialog ofd = OpenFile();
                M2.Source = new Uri(ofd.FileName, UriKind.Relative);
                M2.LoadedBehavior = MediaState.Stop;
            }
    
            private void btnStart_Click(object sender, RoutedEventArgs e)
            {
                M1.LoadedBehavior = MediaState.Play;
                M2.LoadedBehavior = MediaState.Play;
            }
    
            private void btnPause_Click(object sender, RoutedEventArgs e)
            {
                M1.LoadedBehavior = MediaState.Pause;
                M2.LoadedBehavior = MediaState.Pause;
            }
