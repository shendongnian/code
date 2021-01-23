        private string[] TextBoxes = {
                             "EmpName",
                             "Sales",
                             "BasePay",
                             "Commission",
                             "GrossPay",
                             "Deductions",
                             "Housing",
                             "FoodAndClothing",
                             "Entertainment",
                             "Misc"
                            };
        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (string name in TextBoxes)
            {
                TextBox tb = this.Controls.Find("txt" + name, true).FirstOrDefault() as TextBox;
                if (tb != null)
                {
                    tb.Text = "";
                }
            }
            this.txtEmpName.Focus();
        }
