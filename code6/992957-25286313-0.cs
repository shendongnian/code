    if (parameter != null)
    {
      var item = parameter.ClickedItem;
      _navigationService.Navigate("AnimeDetails",
          await Task.Run(() => JsonConvert.SerializeObject(item)));
    }
