    public class Form1
    {
      ...
     public string Parent{ get; set; }
     private void Form1_Load(object sender, EventArgs e)
     {
       MessageBox.Show(this.Parent);
     }
    }
