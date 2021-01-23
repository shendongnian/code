	private void button2_Click(object sender, EventArgs e) {
		if (!Directory.Exists(@"D:\Carpeta"))
			Directory.CreateDirectory(@"D:\Carpeta");
			
		TextWriter sw = new StreamWriter(@"D:\Carpeta\Archivo.txt");
		for(int i = 0; i < TablaDatos.RowCount; ++i) {
			var items = new List<string>();
			foreach (DataGridViewCell cell in TablaDatos.Rows[i].Cells)
				items.Add(cell.ToString());
			File.WriteAllText(@"D:\Carpeta\" + $"Archivo-row -{i}.tsv", string.Join("\t", items));
		}
		MessageBox.Show("Datos Exportados correctamente");
	}
