    int j = DataGD.Items.Count;
    int i = 0;
    do
    {
    DataGridRow row = this.DataGD.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
    ComboBox ele = this.DataGD.Columns[0].GetCellContent(row) as ComboBox;
    string newS = ele.Text;
    list.add(newS);
    i++;
    } while (i < j);
