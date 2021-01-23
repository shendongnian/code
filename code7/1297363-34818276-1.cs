    // Sends a notification message with a Person as content in ProdutoViewModel.
    var produto = new Produto { ProdutoName = "fuu", ProdutoPrice = 78 };
    Messenger.Default.Send(new NotificationMessage<Produto>(produto, "event://FromProdutoViewModelToEncomendaViewModel"));
 
    // Registers for incoming Notification messages EncomendaViewModel.
    Messenger.Default.Register<NotificationMessage<Person>>(this, (message) =>
    { 
        // Checks the associated action.
        switch (message.Notification)
        {
            case "event://FromProdutoViewModelToEncomendaViewModel":
                // Gets the Person object
                var produto = message.Content as Produto;
            
                // Doing Stuff with the produto in EncomendaViewModel
                break;
 
            default:
                break;
        }
    });
