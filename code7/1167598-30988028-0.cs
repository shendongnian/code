    private void setOrderTable()
        {
            string relationString = getRelatedOrders(); //gives the comma delimited string
            string[] sRelationArray = relationString.Split(new[] {','}, System.StringSplitOptions.RemoveEmptyEntries);
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
            try
            {
                this.oRDERSTableAdapter.Fill(this.DBDataSet.ORDERS);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error finding orders. \n" + ex.Message);
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                currencyManager1.SuspendBinding();
                row.Visible = false;
                for (int i = 0; i < sRelationArray.Length; i++)
                {
                    if (sRelationArray[i] == row.Cells[0].Value.ToString())
                    {
                        row.Visible = true;
                    }
                }
            }
            currencyManager1.ResumeBinding();
        }//end set orders table
