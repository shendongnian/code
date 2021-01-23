        private void _theCanvas_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _pointerDeviceType.Text = e.PointerDeviceType.ToString();
            var position = e.GetPosition(_root);
            _x.Text = position.X.ToString();
            _y.Text = position.Y.ToString();
        }
