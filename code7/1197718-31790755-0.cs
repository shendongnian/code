    foreach (var result in thisDocument.Controls.OfType<RichTextContentControl>())
    {
        result.Entering += (sender, args) =>
        {
            MediatorContext.Current.Send(new CurrentKomponenteChangedRequest(result.ID, State.Entering));
        };
        result.Exiting += (sender, args) =>
        {
            MediatorContext.Current.Send(new CurrentKomponenteChangedRequest(result.ID, State.Exiting));
        };
    }
