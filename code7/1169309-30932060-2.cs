    this.BeginInvoke((Action)delegate()
        {
            labelLoading.Text = "Creando orden...";
            labelLoading.Visible = true;
            Models.FirstPhaseModel model = new Models.FirstPhaseModel()
            {
                // Set data.
            };
            orderNumberLabel.Text = _viewModel.FirstPhase(model);
            firstPhaseBtn.Enabled = true;
            labelLoading.Text = string.Empty;
            labelLoading.Visible = false;
        });
