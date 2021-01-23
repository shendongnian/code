    public class Form2 : Form
    {
      Form _form1;
    public Form2(Form1 frm)
    {
      _form1 = frm;
    }
    
    //In event handler
    
    private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
       //set the value
       ((TextBox)_form1.Form1Text).Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
    }
    }
