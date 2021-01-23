    Form obj1 = null;
    for (int i = ((obj1 == null) && (Application.OpenForms.Count - 1)); i >= 0; i--)
    {
        if (Application.OpenForms[i].Name == "Foobar")
            obj1 = Application.OpenForms[i];
    }
    if (obj1 != null)
    {
        this.butn2.Click += new System.EventHandler(obj1 .button_Save_Click);
    }
