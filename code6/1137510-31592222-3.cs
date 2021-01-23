     public partial class TestRibbon
        {
            private string friendlyErrorMessage = "An error has occurred inside the Case Manager Outlook Addin";
    
            private void TestRibbon_Load(object sender, RibbonUIEventArgs e)
            {
                
            }
    
            public TestRibbon()
                : base(Globals.Factory.GetRibbonFactory())
            {
                InitializeComponent();
                try
                {
                    System.Data.DataTable dt = new DBCall().GetData();//Get all menu in word tmenu tab and bind them using following code
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            RibbonButton Field = this.Factory.CreateRibbonButton();
                            Field.Label = dt.Rows[i][1].ToString();
                            Field.Tag = i;
                            Field.ControlSize =
                                Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
                            Field.Click += Field_Click;
                            menu1.Items.Add(Field);
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("No Fields are available in database");
                    }
                }
                catch (Exception exception)
                {
                }
    
    
            }
    
            /// <summary>
            ///  Ribbon Button Click Event 
            /// </summary>
            void Field_Click(object sender, RibbonControlEventArgs e)
            {
                try
                {
                    Microsoft.Office.Interop.Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;
                    currentRange.Text = (sender as RibbonButton).Label;
                }
                catch (Exception exception)
                {
                }
    
            }
    
        }
