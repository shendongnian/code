        List<string> lista = new List<string>();
        lista.Add("test1");
        lista.Add("test2");
        lista.Add("test3");
        for(int i = 0; i < lista.Count; i++)
        {
            tabControl_Roz.TabPages.Add(lista[i]);
            tabControl_Roz.TabPages[i].Controls.Add(new DataGridView(){
                Name="dataGridView_" + lista[i],
                Dock=DockStyle.Fill});
        }
