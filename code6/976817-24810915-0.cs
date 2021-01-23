    void SetTrigger(ContentControl contentControl)
    {
        // create the command action and bind the command to it
        var invokeCommandAction = new InvokeCommandAction { CommandParameter = "btnAdd" };
        var binding = new Binding { Path = new PropertyPath("ButtonClickCommand") };
        BindingOperations.SetBinding(invokeCommandAction, InvokeCommandAction.CommandProperty, binding);
    
        // create the event trigger and add the command action to it
        var eventTrigger = new System.Windows.Interactivity.EventTrigger { EventName = "PreviewMouseLeftButtonDown" };
        eventTrigger.Actions.Add(invokeCommandAction);
        // attach the trigger to the control
        var triggers = Interaction.GetTriggers(contentControl);
        triggers.Add(eventTrigger);
    }
