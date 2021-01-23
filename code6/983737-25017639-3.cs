    private CancellationTokenSource _cts;
    private async void TextBoxSearchText_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (_cts != null)
        _cts.Cancel();
      _cts = new CancellationTokenSource();
      var strSearchText = TextBoxSearchText.Text;
      ListBoxAllTexts.ItemsSource = await Task.Run(
          () => searchText(strSearchText, _cts.Token));
    }
    private List<TextList> searchText(string strSearchText, CancellationToken token)
    {
      try
      {
        return oTextList.AsParallel().WithCancellation(token)
            .Where(item => Regex.IsMatch(item.EnglishText.ToString(), "\\b" + strSearchText.ToLower() + @"\w*", RegexOptions.IgnoreCase))
            .Select(item => new TextList
            {
              Id = item.Id,
              EnglishText = item.EnglishText
            })
            .ToList();
      }
      catch (OperationCanceledException)
      {
        return null;
      }
    }
