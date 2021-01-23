        protected override async void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            await Task.Delay(10);
            if (Text.Length > 0)
            {
                SelectionStart = Text.Length;
            }
        }
