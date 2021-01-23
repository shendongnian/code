		/// <summary>
		/// Give a Table that contains the foreignkeys it returns a Table with a Description instead of the Key
		/// The ID in the source has to be Column[0]
		/// </summary>
		/// <param name="foreignkeys">Foreignkey in you Table</param>
		/// <param name="source">The Table the foreignkey refers to</param>
		/// <param name="_foreigncolumn">Header of Foreignkeycolumn</param>
		/// <param name="_sourcecolumn">Header description column in source Table</param>
		/// <returns></returns>
		public DataTable getDatabyForeignKey(DataTable foreignkeys, DataTable source, string _foreigncolumn, string _sourcecolumn)
		{
            try
            {
                DataTable displayname = new DataTable();
                displayname.Columns.Add("ID");
                //Maybe change that to a parameter as well (amount + header)
                displayname.Columns.Add("Description");
                for (int i = 0; i < foreignkeys.Rows.Count; i++)
                {
                    for (int j = 0; j < source.Rows.Count; j++)
                    {
                        string s = source.Rows[j][0].ToString();
                        string ss = foreignkeys.Rows[i][_foreigncolumn].ToString();
                        if (source.Rows[j][0].ToString() == foreignkeys.Rows[i][_foreigncolumn].ToString())
                        {
                            foreignkeys.Rows[i][_foreigncolumn] = source.Rows[j][_sourcecolumn];
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(ex.Message);               
            }
			     
			return foreignkeys;
		}
