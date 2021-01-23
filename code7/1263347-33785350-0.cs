    private async void ProcessCommands()
    {
        while(_items.count > 0)
        {
            var command = _items[0] as IAsyncCommandItem;
            if (command != null)
            {
                await command.Execute();
            }
            else
            {
                _items[0].Execute();
            }
            _items.RemoveAt(0);
        }
    }
