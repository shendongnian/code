    private void OnKeyDownHandler(object sender, KeyEventArgs e) {     
      if (e.Key == Key.Enter) {
        MessageBox.Show(cardReadBuffer);
        cardReadBuffer = "";
        e.Handled = true;
      }
    }
    private void OnTextInput(object sender, TextCompositionEventArgs e) {
      cardReadBuffer += e.Text;
    }
