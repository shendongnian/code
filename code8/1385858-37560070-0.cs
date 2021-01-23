    decimal valorAcumulado = 0;
    for (int i = 0; i < listView.Items.Count; i++)
    {
        valorAcumulado += decimal.Parse(listView.Items[i].SubItems[4].Text);
    }
    Console.WriteLine(valorAcumulado); // 83
