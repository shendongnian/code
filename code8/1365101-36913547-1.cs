    enum ButtonType
    {
      Ok,
      Cancel,
      Whatever
    }
    
    Dictionary<ButtonType, ButtonConfig> buttons = new Dictionary<ButtonType, ButtonConfig>()
    {
      {ButtonType.Ok, new ButtonConfig { Name = "OKBtn", Text = "OK" }},
      {ButtonType.Cancel, new ButtonConfig { Name = "CancelBtn", Text = "Cancel" }},
      {ButtonType.Whatever, new ButtonConfig { Name = "WhateverBtn", Text = "Whatever" }},
    };
