            private bool isRunning;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            var flashButton = FindResource("FlashButton") as Storyboard;
            var changeColor = FindResource("ChangeColor") as Storyboard;
            var changeColor2 = FindResource("ChangeColor2") as Storyboard;
            if (isRunning)
            {
                flashButton.Stop();
                changeColor2.Begin();
                isRunning = false;
            }
            else
            {
                flashButton.Begin();
                changeColor.Begin();
                isRunning = true;
            }
        }
