    public class Form1
    {
       ...
       public void Clear() 
       {
           DataGridView1.Rows.Clear();
       }
    
       public void btnOpenForm2_Click(object sender, EventArgs e)
       {
          var form2 = new Form2(this); // create a new form2, and pass a reference to form1
          form2.Show(); // show the form.
       }
       ...
    }
