    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApplication3
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void mySetQuestion(object sender, EventArgs e)
            {
                mshtml.HTMLDocument document = (mshtml.HTMLDocument)WebBrowser1.Document;
                mshtml.IHTMLElement textArea = document.getElementById("myQuestion1");
                textArea.innerHTML = "What is 1+1?";
            }
            private void myGetAnswer(object sender, EventArgs e)
            {
                mshtml.HTMLDocument document = (mshtml.HTMLDocument)WebBrowser1.Document;
                mshtml.IHTMLElement textArea = document.getElementById("myStudentInput1");
                textBlock.Text = textArea.innerHTML;
            }
        }
    }
