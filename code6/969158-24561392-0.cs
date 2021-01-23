    Style style = new Style { TargetType = typeof(Button) };
    DataTrigger trigger = new DataTrigger
        {
            Binding = new Binding("IsKeyboardFocusWithin") { ElementName = "txtBox1" },
            Value = true
        };
    trigger.Setters.Add(new Setter { Property = Button.BackgroundProperty,
         Value = Brushes.Red });
    style.Triggers.Add(trigger);
    Button btn = new Button { Content = "Test button", Style = style };
