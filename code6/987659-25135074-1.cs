    private string GetText()
    {
        ChatViewModel vm = this.DataContext as ChatViewModel;
        if(vm != null)
            return vm.MessageInput;
         else
            return string.Empty;
    }
