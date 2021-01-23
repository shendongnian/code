    private async void btnDecode_Click(object sender, RoutedEventArgs e)
    {
        string result = await DecodedResult((BitmapSource)imageBarcode.Source);
        txtBarcodeContent.Text = result;
    }
    private async Task<string> DecodedResult(BitmapSource renderTargetBitmap)
    {
        object decoded = await reader.Decode(renderTargetBitmap);
        return decoded.ToString();
    }
