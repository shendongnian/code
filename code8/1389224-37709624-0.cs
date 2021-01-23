    private void GENIO_Code_Editor_Load(object sender, EventArgs e)
    {
        try
        {
            buttonDetect.Enabled = m_dbDatabase != null;
            InitColourComboBoxColumn();
            dataGridView.Columns.Add("Layer", "Layer");
            dataGridView.Columns.Add(cboColumn);
            if (textBoxXML.Text != "")
                ReadXmlToGrid();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
