    InlineUIContainer uiContainer = new InlineUIContainer();
    HyperlinkButton b = new HyperlinkButton();
    b.Content = runText.Text;
    b.NavigateUri = uri;
    b.Tag = uri;
    b.Click += (s, args) =>
    {
        //Your click logic here.
    };
    uiContainer.Child = b;
    paragraph.Inlines.Add(uiContainer);
