    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        var panel = new System.Windows.Forms.Panel { Dock = DockStyle.Fill };
        var form = new Form { Size = new Size(800, 600), Text = "WPF Host Form" };
        form.Controls.Add(panel);
        var rectangle = new System.Windows.Shapes.Rectangle { Fill = System.Windows.Media.Brushes.White, Width = 100, Height = 100 };
        var canvas = new Canvas { Background = System.Windows.Media.Brushes.Black,
            Focusable = true};
        canvas.Children.Add(rectangle);
        var userControl = new System.Windows.Controls.UserControl { Content = canvas };
        var elementHost = new ElementHost { Child = userControl, Dock = DockStyle.Fill };
        panel.Controls.Add(elementHost);
        // form.KeyDown += (sender, args) => MessageBox.Show("Key pressed!");
        canvas.KeyDown += (sender, args) => MessageBox.Show("Key pressed!");
        Application.Run(form);
    }
