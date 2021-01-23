    [WhateverYourDataLayerNeeds("Property")]
    public string EncryptedProperty {get;set;}
    public string DecryptedProperty
    {
        get { return DecryptString(EncryptedProperty); }
        set { EncryptedProperty = EncryptString(value); }
    }
