    Dispatcher.Invoke(new Action(() => {   
       Run r = new Run((string)name + Environment.NewLine);
       r.Foreground = Brushes.Green;
       currentlyOnlineParagraph.Inlines.Add(r);   
    }), DispatcherPriority.ContextIdle);
