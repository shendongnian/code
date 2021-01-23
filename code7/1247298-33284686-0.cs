     class Program
      {
        static WindowsFormsApplication1.Form1 frm;
        static void Main(string[] args)
        {
          frm = new WindowsFormsApplication1.Form1();
          frm.textBox1.TextChanged += textBox1_TextChanged;
          System.Windows.Forms.Application.Run(frm);
    
        }
        static void textBox1_TextChanged(object sender, EventArgs e)
        {
          Console.WriteLine((frm.textBox1.Text));
        }
      }
