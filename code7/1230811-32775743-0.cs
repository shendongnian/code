         protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "") 
            {
                File[] pdffiles = Directory.GetFiles(@"\\192.168.5.10\fbar\REPORT\CLOTHO\H2\REPORT\", "*.pdf", SearchOption.AllDirectories);
                string search = TextBox1.Text;
                ListBox1.Items.Clear();
                foreach (var file in pdffiles)
                {
                    if(file.Name==search)
                    {
                    ListBox1.Items.Add(Path.GetFileName(file));
                    }
                }
                TextBox1.Focus();
            }
            else
            {
                Response.Write("<script>alert('For this Wafer ID Report is Not Generated');</script>");
            }
        }
