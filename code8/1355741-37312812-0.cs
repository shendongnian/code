    using System;
    using System.Windows.Forms;
    
    namespace CurrentInputLanguageTest
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Console.WriteLine(InputLanguage.CurrentInputLanguage.LayoutName); // It's US
                Console.ReadLine(); // Changed my keyboard layout while typing something
                Console.WriteLine(Application.CurrentInputLanguage.LayoutName); // It's still US
    
                var form = new Form();
                var grid = new TableLayoutPanel();
                var button = new Button();
                var button2 = new Button();
                button2.Left = button.Right + 5;
                form.Refresh();
                button.Click += CheckInputLanguage;
                button2.Click += ChangeInputLanguage;
                form.Controls.Add(button);
                form.Controls.Add(button2);
                Application.Run(form);
            }
    
            private static void ChangeInputLanguage(object sender, EventArgs e)
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            }
    
            static void CheckInputLanguage(object sender, EventArgs e)
            {
                // I have changed my input language while the form is opened and pressed the button.
                // It changes when called in this event handler.
                Console.WriteLine(InputLanguage.CurrentInputLanguage.LayoutName);
            }
        }
    }
