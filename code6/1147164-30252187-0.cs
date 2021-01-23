    OleDbCommand cmd = new OleDbCommand("SELECT Table1.Cd_AtributosNormais as Cd_AtributosNormais, Table2.Nm_Atr as Nm_Atr FROM Table1 Left outer join Table2 on Table1.Cd_AtributosNormais = Table2.Cd_AtributosNormais", cn);
                OleDbDataReader reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                DataRow row = table.NewRow();
                row["Nm_Atr"] = "";
                table.Rows.InsertAt(row, 0);
    
                this.btCmbAtkBaAtr1.DataContext = table.DefaultView;
                this.btCmbAtkBaAtr1.DisplayMemberPath = "Nm_Atr";
                this.btCmbAtkBaAtr1.SelectedValuePath = "Cd_AtributosNormais";
                cmd.ExecuteNonQuery();
                reader.Close();
                reader.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
