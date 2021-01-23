    public Button<TEnum> GetButton(TEnum Identifier) {
        var button = _buttons.Where(b => b.Identifier.Equals(Identifier)).FirstOrDefault();
        if (button == null)
            Debug.Log("'" + GetType().Name + "' cannot return an <b>unregistered</b> '" + typeof(Button<TEnum>).Name + "' that listens to '" + typeof(TEnum).Name + "." + Identifier.ToString() + "'.");
        return button;
    }
    
