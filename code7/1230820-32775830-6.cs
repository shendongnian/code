    protected void Button1_Click(object sender, EventArgs e)
            {
               string search = TextBox1.Text;
    
                if (TextBox1.Text != "") 
                {
                    string[] pdffiles = Directory.GetFiles(@"\\192.168.5.10\\fbar\\REPORT\\CLOTHO\\H2\\REPORT\\", string.Format("*{0}*.pdf",search), SearchOption.AllDirectories);
                    
                    ListBox1.Items.Clear();
                    foreach (string file in pdffiles)
                    {
    
                        ListBox1.Items.Add(Path.GetFileName(file));
                    }
    
                    TextBox1.Focus();
                }
                else
                {
                    Response.Write("<script>alert('For this Wafer ID Report is Not Generated');</script>");
    
    
                }
            }
