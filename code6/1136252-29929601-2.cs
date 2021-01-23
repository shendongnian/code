    public Button<TEnum> GetButton(TEnum Identifier) {
        var button = _buttons
            .Where(b => EqualityComparer<TEnum>.Default.Equals(b.Identifier, Identifier))
            .FirstOrDefault();
        if (button == null)
            Debug.Log("'" + GetType().Name + "' cannot return an <b>unregistered</b> '" + typeof(Button<TEnum>).Name + "' that listens to '" + typeof(TEnum).Name + "." + Identifier.ToString() + "'.");
        return button;
    }
    
