    private void OnButton1_Clicked(object sender, ...)
    {
        using (var settingsForm = new SettingsForm)
        {
            settingsForm.TimerTime = this.TimerTime;
            settingsForm.Setting1 = this.Setting1;
            settingsForm.Setting2 = this.Setting2;
            // now that the settings form is initialized
            // we can show it and wait until the user closes the form
            var dlgResult = settingsForm.ShowDialog(this);
            // only use the new settings if the operator pressed OK:
            if (dlgResult == DialogResult.OK)
            {
                this.TimerTime = settingsForm.TimerTime;
                this.Setting1 = settingsForm.Setting1;
                this.Setting2 = settingsForm.Setting2;
                this.ProcessChangedSettings();
            }
        }
    }
