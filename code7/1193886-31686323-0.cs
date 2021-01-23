    async void board_EmergencyButtonEvent(object sender, EventArgs e)
    {
        IsEmergencyButtonActive = taskBegunState;       
        await Task.Run(() => { ...Long Running Code... });
        IsEmergencyButtonActive = taskCompleteState;
    }
