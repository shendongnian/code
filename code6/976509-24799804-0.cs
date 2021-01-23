    namespace Test
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void testButton_Click(object sender, EventArgs e)
            {
                GeneratedClass gc = new GeneratedClass(testTXT);
                gc.DoSomething();
                gc.CreatePackage("C:\\Users\\user\\Downloads\\output.docx");
            }
    
            private void browseButton_Click(object sender, EventArgs e)
            {
                var fsd = new FolderSelect.FolderSelectDialog();
                fsd.Title = "Select folder to save document";
                fsd.InitialDirectory = @"c:\";
                if (fsd.ShowDialog(IntPtr.Zero))
                {
                    testTXT.Text = fsd.FileName;
                }
            }
        }
    
        public class GeneratedClass
        {
              TextBox _txt;
              public GeneratedClass(TextBox txt)
              {
                _txt= txt;
              }
             
              public void DoSomething()
              {
                txt.Text = "Changed the text";
              }
        }
    }
