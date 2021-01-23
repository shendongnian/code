    do
    {
        var availableReaders = this.ListReaders();
        // If you're only using `states` in this method,
        // make it a local variable:
        var states = availableReaders
            .Select(r => new ReaderState() { Reader = r.ToString() })
            .ToArray();
        // fill the data
        result = (SmartcardErrorCode)UnsafeNativeMethods
            .GetStatusChange(this._context, 1000, states, states.Length);
        // this is the important part: create a new instance of reader names.
        // LINQ also simplifies it a bit:        
        var availableReaders = states
            .Where(s => s._attribute != 0)
            .Select(s => s._reader)
            .ToList();
                
        // now that you have a local list, you can simply swap the field 
        // which is referencing it (since object assignments are atomic in .NET).
        // So the field gets a unique copy every time, and you can even go
        // an extra step forward by declaring it as a `ReadOnlyCollection<string>`:
        szAvailableReaders = new ReadOnlyCollection<string>(availableReaders);
        // Consider using `Invoke` here:        
        this.Dispatcher.BeginInvoke((Action)(() =>
        {
            NumberOfCards.Items.Clear();
            NumberOfCards.Items.AddRange(szAvailableReaders.ToArray());
        }));
        
    } while (SetThread);
