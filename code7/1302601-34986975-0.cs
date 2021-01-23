    foreach (Button button in buttons)
    {
        string _name = button.name;
        button.onClick.AddListener(() => OnUIButtonClick(_name)); 
    }
