    List<string> camaras = new List<string>();
    foreach (FilterInfo item in usbCams)
    {
        camaras.Add(item.Name);
    }
    comboBox.ItemsSource = camaras;
