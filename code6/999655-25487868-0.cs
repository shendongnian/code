     Dispatcher.Invoke(((Action)(() => ]
          {
             this.IsTestRunning = false;
             CommandManager.InvalidateRequerySuggested();
          })));
