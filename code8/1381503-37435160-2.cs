        // in the constructor....
        this.Activate += Main_ViewModel_Activate;
        this.DeActivate += Main_ViewModel_DeActivate;
        private void Main_ViewModel_DeActivate(object sender, ActivateArgs e)
        {
        }
        private void Main_ViewModel_Activate(object sender, ActivateArgs e)
        {
            // e.Data will be the SendObject from AviewModel
        }
