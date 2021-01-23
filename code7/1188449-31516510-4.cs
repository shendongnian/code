    private async void QuoteWindow_Loaded(object sender, RoutedEventArgs e)
    {
        using (TruckServiceClient TSC = new TruckServiceClient())
        {
            await LoadItems(TSC, QuoteOptionType.BodyType, cmbBodyType);
            await LoadItems(TSC, QuoteOptionType.Chassis, cmbChassisCab);
            await LoadItems(TSC, QuoteOptionType.PaintColor, cmbPaint);
            await LoadItems(TSC, QuoteOptionType.DropSide, cmbDropsideHeight);
            await LoadItems(TSC, QuoteOptionType.Floor, cmbFloor);
            await LoadItems(TSC, QuoteOptionType.RearDropSide, cmbRearDropsideHeight);
            await LoadItems(TSC, QuoteOptionType.Extras, cmbAddExtras);
        }
    
        combAddExtras.SelectionChanged += cmbAddExtras_SelectionChanged;
    }
    private void cmbAddExtras_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = cmbAddExtras.SelectedItem;
    
        if (item != null)
            dgAddExtras.Items.Add(item);
    }
