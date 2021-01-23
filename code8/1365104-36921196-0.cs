    public enum ButtonType { mbOK, mbCancel, mbYes, mbNo };
    
    class ButtonConfig
        {
            public string Name { get; set; }
            public string Text { get; set; }
            public string ModelResult { get; set; }
        }
    
    private static Dictionary<ButtonType, ButtonConfig> ButtonsSettings = new Dictionary<ButtonType, ButtonConfig>()
            {
                {ButtonType.mbOK, new ButtonConfig { Name = "btnOK", Text = "OK", ModelResult = "mrOk"}},
                {ButtonType.mbCancel, new ButtonConfig { Name = "btnCancelBtn", Text = "Cancel", ModelResult = "mrCancel" }},
                {ButtonType.mbYes, new ButtonConfig { Name = "btnYes", Text = "Yes", ModelResult = "mrYes" }},
                {ButtonType.mbNo, new ButtonConfig { Name = "btnNo", Text = "No", ModelResult = "mrNo"}},
