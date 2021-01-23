	~ProgramWizardViewModel()
    {
        if ((Program.Errors.Count > 0)
                         && (WizardData?.User != null))
        {
            string errorsText = string.Format(string.Join("\n", Program.Errors));
            WizardData.client.UploadExceptionReport(errorsText).Wait();
        }
    }
