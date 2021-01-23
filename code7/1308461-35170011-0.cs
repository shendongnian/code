    Observable.FromEventPattern<TextChangedEventHandler, TextChangedEventArgs>(
      handler => this.TextChanged += handler,
      handler => this.TextChanged -= handler)     
         .ObserveOn(DispatcherScheduler.Current)
         .Throttle(TimeSpan.FromMilliseconds(600))
         .Where(e =>
              {
                  var control= e.Sender as TextBox;
                  return control!= null && !string.IsNullOrEmpty(control.Text);
              })
         .Subscribe(x => Control_TextChanged(x.Sender, x.EventArgs));
