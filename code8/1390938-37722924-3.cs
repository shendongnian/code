    private async void AccessElements()
    {
        TaxoProcess Taxo = new TaxoProcess();
        if (await Taxo.AccessEntity())
        {
            MessageBox.Show("Succesfully Extracted Data", "Extract Application", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    public async Task<bool> AccessEntity()
    {
        
        return Task.Run(() =>
            {
            try
            {
                for (int i = 0; i < Entities.Count; i++)
                {
                   await Task.Delay(100);
                    int PercentageValue = (int)(0.5f + ((100f * i) / Entities.Count));
                    StaticDataProperties.ProgBar.Value = PercentageValue;
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorException = ex.Message;
                return false;
            }
        });
    }
