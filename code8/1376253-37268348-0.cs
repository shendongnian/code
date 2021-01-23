     private void Form1_Load(object sender, EventArgs e)
        {
        
            var Header = new BindingList<KeyValuePair<string, string>>();
            List<string> LV = ListHeader();
            foreach (var listOut in LV)
            {
                Header.Add(new KeyValuePair<string, string>(listOut, "val"+listOut));
            }
            tableComboBox.DataSource = Header;
            tableComboBox.DisplayMember = "Key";
            tableComboBox.ValueMember = "Value";
        }
    
    
    public List<string> ListHeader()
    {
        List<string> list = new List<String>();
    
        try
        {
            cmd.Connection = db.connection;
            
            cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE';";
    
            var reader = cmd.ExecuteReader();
              for(int i=0;i<reader.FieldCount;i++)
              {
                list.Add(reader.GetName(i));
              }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Get Header",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            con.Close();
        }
    
        return list;
    }
