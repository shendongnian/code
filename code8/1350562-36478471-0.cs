    public partial class Form1 : Form
    {
      private Dictionary<string,SizeF> paperSizes = new Dictionary<string,SizeF>();
      public Form1()
      {
         InitializeComponent();
      }
      private void Form1_Load(object sender, EventArgs e)
      {
         paperSizes.Add("A2", new SizeF(420, 594));
         paperSizes.Add("A3", new SizeF(297, 420));
         paperSizes.Add("A4", new SizeF(210, 297));
         paperSizes.Add("A5", new SizeF(148, 210));
         comboBox1.Items.AddRange(paperSizes.Keys.ToList<string>().ToArray());
      }
      private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (comboBox1.Text.Length > 0)
         {
            if (paperSizes.ContainsKey(comboBox1.Text))
            {
               MessageBox.Show(String.Format("{0} = {1} x {2}", comboBox1.Text, paperSizes[comboBox1.Text].Width, paperSizes[comboBox1.Text].Height));
            }
         }
      }
    }
