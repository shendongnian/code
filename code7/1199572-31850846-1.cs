    private void RaiseConfirmation()
    {
        this.ConfirmationRequest.Raise(
            new Confirmation { Content = "Confirmation Message", Title = "Confirmation" },
            c => { InteractionResultMessage = c.Confirmed ? "The user accepted." : "The user cancelled."; });
    }
