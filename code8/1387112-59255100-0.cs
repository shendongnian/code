                    <Label LineBreakMode="WordWrap">
                        <Label.FormattedText>
                            <FormattedString>
                                <Span Text="Google">
                                    <Span.GestureRecognizers>
                                        <TapGestureRecognizer Tapped="Handle_Tapped" />
                                    </Span.GestureRecognizers>
                                </Span>
                            </FormattedString>
                        </Label.FormattedText>
                    </Label>
      public async void Handle_Tapped(object sender, EventArgs e)
        {
            await Browser.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
        }
