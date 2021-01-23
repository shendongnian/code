    private void ConfigureViewModel(PayNowViewModel model)
    {
      model.ExpiryMonth = Enumerable.Range(1, 12).Select(m => new SelectListItem
      {
        Value = m.ToString(),
        Text = m.ToString("00")
      });
      model.ExpiryYear = Enumerable.Range(DateTime.Today.Year, 10).Select(y => new SelectListItem
      {
        Value = y.ToString(),
        Text = y.ToString("00")
      });
    }
