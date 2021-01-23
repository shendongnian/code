    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
    
            SuppliersProducts(ProductsList,e.RowIndex);
        }
    static public void SuppliersProducts(DataGridView _productslist,int index)
       {
           try
           {
               connection.Open();
              
               string commandShow=String.Format("SELECT a.Name FROM Products a INNER JOIN SuppliersProducts b ON a.Id = b.ProductId WHERE b.SupplierId = {0}",_productslist.Rows[index].Cells[0].Value));
               //Stroing sql server data
              var dt = new DataTable();
              using (var da = new SqlDataAdapter(commandShow, connection))
                  da.Fill(dt);
               foreach(DataRow row in dt.Rows)
               {
                    dataGridView2.Rows.Add(row[0],...);
               }
           }
           catch (SqlException exception)
           {
               MessageBox.Show(exception.ToString());
           }
           finally
           {
               connection.Close();
           }
       }
