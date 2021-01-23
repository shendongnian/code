    public ProgressDialogController dialog;
    
    public async Task showMessaggeAsyncFromMainWindow()
    {
        dialog = await this.ShowProgressAsync(Properties.strings.attendi, Properties.strings.aggiornamentoMeetingsInCorso, false) as ProgressDialogController;
    }
    
    public async Task closeMessaggeAsyncFromMainWindow()
    {
        await dialog.CloseAsync();
    }
