    <asp:Button ID="delete" runat="server" CommandArgument='<%#Eval("Id") %>'  Text="Delete" />
        private void delete_btn_Click(object sender, EventArgs e)
            {
              //incase you need the row index 
            int rowIndex = ((GridViewRow)((Button)e.CommandSource).NamingContainer).RowIndex;
            int Prod_Id= Convert.ToInt32(e.CommandArgument);
            //followed by your code 
                try
                {
                    // Then Compare your Id here in this if condition
                    // if (dataGridView1.Rows.Cell[0].Text == TextBox1.tex
                    if (Prod_id == Convert.ToInt32(TextBox1.text)) // error on this line.
                    {
                         // User Code Here
                    }
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Not able to Delete");
                }
            }
