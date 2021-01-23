    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            void btn_Sub_MouseEnter(object sender, MouseEventArgs e)
            {
                try { sub_Background.Fill = Brushes.Red; } catch { }
            }
            void btn_Sub_MouseLeave(object sender, MouseEventArgs e)
            {
                try { sub_Background.Fill = (Brush)FindResource("SubBack"); } catch { }
            }
            void btn_Sub_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Subtitles");
            }
    
            void btn_Audio_MouseEnter(object sender, MouseEventArgs e)
            {
                try { Audio_Background.Fill = Brushes.Purple; } catch { }
            }
            void btn_Audio_MouseLeave(object sender, MouseEventArgs e)
            {
                try { Audio_Background.Fill = (Brush)FindResource("AudioBack"); } catch { }
            }
            void btn_Audio_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Audio");
            }
        }
