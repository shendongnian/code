    InputManager.Current.PreProcessInput += delegate(object sender, PreProcessInputEventArgs args)
        {
            mIdle.IsEnabled = false;
            mIdle.IsEnabled = true;
        };
