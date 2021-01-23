    using System.Linq;
    public void button2_Click_3(object sender, EventArgs e)
    {
       bool invalid = this.Controls.OfType<TextBox>()
         .Where(t => t.IsVisible)
         .Any(t => string.IsNullOrWhiteSpace(t.Text);
       if (invalid)
         MessageBox.Show("can't continue");
     }
 
   
