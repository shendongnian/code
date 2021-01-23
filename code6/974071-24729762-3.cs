    using System;
    using System.Windows.Forms;
    using AxSimpleActiveXControlLib;
    
    class Program
    {
        [STAThread]
        static void Main()
        {
            var c = new AxSimpleActiveXControlLib.AxSimpleActiveXControl();
    
            var form = new Form
            {
                Controls = { c }
            };
    
            form.Load += (s, e) => MessageBox.Show(c.GetSomeNumber().ToString());
    
            Application.Run(form);
        }
    }
