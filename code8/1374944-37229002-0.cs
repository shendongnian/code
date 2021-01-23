    foreach (CheckBox c in checkboxes)
    {
        if (c.IsChecked)
        {
            ClassDados cDados = new ClassDados();               
            cDados.Pedido = c.Content.ToString();
            lista.Add(cDados);
        }
    }
