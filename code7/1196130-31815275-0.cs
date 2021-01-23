        if (publish.Steps[publish.CurrentStepIndex].GetType() == typeof(Step1ViewModel))
        {
            var model = publish.Steps[publish.CurrentStepIndex] as Step1ViewModel;
            // Do some magic
        }
