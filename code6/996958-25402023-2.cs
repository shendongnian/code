    private void Solve(int row, int column, int box)
        {
            string numbers = "123456789";
            TextBox newTextBox = (TextBox)Controls.Find(string.Format("tbox{0}", "R" + row.ToString() + "C" + column.ToString() + "B" + box.ToString()), false).FirstOrDefault();
    
             if(newTextBox!=null)
             {
                 MessageBox.Show(newTextBox.Text);
                 return;
             }
            numbers = numbers.Replace(checkRow(row, column), "");
            numbers = numbers.Replace(checkColumn(row, column), "");
            numbers = numbers.Replace(checkBoxPos(row, column), "");
    
            if (numbers.Length == 1)
             {
                newTextBox.Text = numbers;
             }
        }
