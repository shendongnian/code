    private async void TypeText()
    {
        Input.Focus(FocusState.Programmatic);
        //we must yield the UI thread so that focus can be acquired
        await Task.Delay(100); 
        InputInjector inputInjector = InputInjector.TryCreate();
        foreach (var letter in "hello")
        {
            var info = new InjectedInputKeyboardInfo();
            info.VirtualKey = (ushort)((VirtualKey)Enum.Parse(typeof(VirtualKey), 
                                       letter.ToString(), true));
            inputInjector.InjectKeyboardInput(new[] { info });
            
            //and generate the key up event next, doing it this way avoids
            //the need for a delay like in Martin's sample code.
            info.KeyOptions = InjectedInputKeyOptions.KeyUp;
            inputInjector.InjectKeyboardInput(new[] { info });
        }
    }
