        double m_MouseX;
        double m_MouseY;
        double m_ClickedX;
        double m_ClickedY;
[...]
        private void Button1_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            m_ClickedX = m_MouseX;
            m_ClickedY = m_MouseY;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (m_ClickedX == m_MouseX && m_ClickedY == m_MouseY)
            {
                MessageBox.Show("HI");
            }
        }
