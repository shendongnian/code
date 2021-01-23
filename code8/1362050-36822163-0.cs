    private async void kalendar_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            dialog = new ContentDialog();
            dialog.Title = args.AddedDates[0].Date.ToString() + "    " + Daten.LadeAktuellenBenutzer()?.mitarbeiter.vorname + " " + Daten.LadeAktuellenBenutzer()?.mitarbeiter.name;
            dialog.MaxWidth = this.ActualWidth;
            panel = new StackPanel();
            aufgaben = new TextBlock();
            aufgaben.Text = "Sie haben an diesem Tag folgendes zu tun:\n";
            aufgaben.TextWrapping = TextWrapping.Wrap;
            panel.Children.Add(aufgaben);
            await dialog.showAsync();
        }
