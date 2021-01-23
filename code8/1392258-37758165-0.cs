    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    // populate textboxes
                    var boxs = new[] {textBox1, textBox2};
    
                    // get user input
                    var decimals = new List<decimal>();
                    var expenses = GetExpenses(boxs, decimals);
                    if (!expenses)
                        throw new InvalidOperationException("Expecting numbers");
    
                    // write to file
                    using (var stream = File.Create("output.txt"))
                    using (var writer = new StreamWriter(stream))
                    {
                        foreach (var d in decimals)
                        {
                            writer.WriteLine(d);
                        }
    
                        var total = decimals.Sum();
                        writer.WriteLine("Total: " + total);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
    
            private bool GetExpenses(TextBox[] boxs, List<decimal> list)
            {
                if (boxs == null) throw new ArgumentNullException(nameof(boxs));
                if (list == null) throw new ArgumentNullException(nameof(list));
                foreach (var box in boxs)
                {
                    var text = box.Text;
                    decimal result;
                    if (!decimal.TryParse(text, out result))
                        return false;
    
                    list.Add(result);
                }
                return true;
            }
        }
    }
