    private async void SetRadioState(bool isRadioOn)
    {
        var radioState = isRadioOn ? RadioState.On : RadioState.Off;
        Disable();
        await this.radio.SetStateAsync(radioState);
        NotifyPropertyChanged("IsRadioOn");
        Enable();
    }
