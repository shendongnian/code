    public string GetLoginCode()
    {
        string retVal;
        Thread viewThread = new Thread(() =>
        {
            CodeRequestView view = new CodeRequestView();
            CodeRequestViewModel viewModel = new CodeRequestViewModel();
            view.ShowDialog();
            retVal = viewModel.Code;
            });
        }
        viewThread.SetApartmentState(ApartmentState.STA);
        viewThread.Start();
        return retVal;
    }
