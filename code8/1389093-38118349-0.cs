    public void Update(DataSet DBDataSet)
    {
        DataAdapter.RowUpdating += before_update;
        DataAdapter.Update(DBDataSet);
    }
    
    public void before_update(object sender, EventArgs e)
    {
        //Convert EventArgs to OleDbRowUpdatingEventArgs to be able to use OleDbCommand property
        System.Data.OleDb.OleDbRowUpdatingEventArgs oledb_e = (System.Data.OleDb.OleDbRowUpdatingEventArgs) e;
        //Get query template
        string cmd_txt = oledb_e.Command.CommandText;
        //Modify query template here to fix it
        //cmd_txt = cmd_txt.Replace("table_name", "\"table_name\"");
        //fill tamplate with values
        string cmd_txt_filled = cmd_txt;
        foreach(System.Data.OleDb.OleDbParameter par in oledb_e.Command.Parameters)
        {
            string par_type = par.DbType.ToString();
            string string_to_replace_with = "";
            if (par.Value.GetType().Name == "DBNull")
            {
                string_to_replace_with = "NULL";
            }
            else
            {
                if (par_type == "Int32")
                {
                    par.Size = 4;
                    string_to_replace_with=Convert.ToInt32(par.Value).ToString();
                }
                else if (par_type == "Double")
                {
                    par.Size = 8;
                    string_to_replace_with=Convert.ToDouble(par.Value).ToString().Replace(",",".");
                }
                else if (par_type == "DateTime")
                {
                    par.Size = 8;
                    /* In Paradox SQL queries you can't just specify the date as a string,
                     * it will result in incompatible types, you have to count the days
                     * between 30.12.1899 and the required date and specify that number
                     */
                    string_to_replace_with = DateToParadoxDays(Convert.ToDateTime(par.Value).ToString("dd.MM.yyyy"));
                }
                else if (par_type == "String")
                {
                    string_to_replace_with = '"' + Convert.ToString(par.Value) + '"';
                }
                else
                {
                    //Break execution if the field has a type that is not handled here
                    System.Diagnostics.Debugger.Break();
                }
            }
            //Prevent replacing (Nkmz = ?) with (Nkmz = NULL)
            //that is replace (Nkmz = ?) with (Nkmz IS NULL)
            if (string_to_replace_with == "NULL")
            {
                int pos = cmd_txt_filled.IndexOf("?");
                for (int i = pos - 1; i >= 0; i--)
                {
                    string chr = cmd_txt_filled.Substring(i, 1);
                    if (chr == " ") continue;
                    if (chr == "=")
                    {
                        cmd_txt_filled = cmd_txt_filled.Substring(0, i) + "IS" + cmd_txt_filled.Substring(i + 1);
                    }
                    break;
                }
            }
            cmd_txt_filled = ReplaceFirst(cmd_txt_filled, "?", string_to_replace_with);
        }
        //Get query text here to test it in Database Manager
        //System.Diagnostics.Debug.WriteLine(cmd_txt_filled);
        
        //Uncomment this to apply modified query template
        //oledb_e.Command.CommandText = cmd_txt;
        
        //Uncomment this to simply run the prepared update command
        //oledb_e.Command.CommandText = cmd_txt_filled;
    }
    public string ReplaceFirst(string text, string search, string replace)
    {
        int pos = text.IndexOf(search);
        if (pos < 0)
        {
            return text;
        }
        return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
    }
    private static string DateToParadoxDays(string date)
    {
        return (Convert.ToDateTime(date) - Convert.ToDateTime("30.12.1899")).TotalDays.ToString();
    }
