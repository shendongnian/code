    using Windows.UI.Xaml.Controls;
    namespace App1
    {
        public sealed partial class MyHeader : UserControl
        {
            public MyHeader()
            {
                this.InitializeComponent();
            }
            public string PageTitle
            {
                get { return Title.Text; }
                set { Title.Text = value ?? ""; }
            }
        }
    }
