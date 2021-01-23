    private void goHome() {
            var bs = Frame.BackStack.Where(b => b.SourcePageType.Name == "MainPage").FirstOrDefault();
            if (bs != null)
            {
                Frame.BackStack.Clear();
                Frame.BackStack.Add(bs);
            }
            this.Frame.GoBack();
    }
