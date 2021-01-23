    private bool SaveTextViewState {
        get {
            if (TextMode == TextBoxMode.Password) {
                return false;
            }
            if (Events[EventTextChanged] != null || !IsEnabled || !Visible || (ReadOnly) || this.GetType() != typeof(TextBox)) {
                return true;
            }
            return false;
        }
    }
