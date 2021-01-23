    private static void CreateForm()
    {
        var SampleForm = new Form();
        SampleForm.Name = "formname";
        SampleForm.Text = "Form Caption";
        SampleForm.Show();
        SampleForm.Shown += new EventHandler(SampleForm_Shown);
    }
    
    private static void SampleForm_Shown(object sender, EventArgs e)
    {
        var SampleForm = (Form)sender;
        GetElements(SampleForm);
        GetButtons(SampleForm);
    }
    
    private static void GetElements(Form SampleForm)
    {
        TextBox textdata = new TextBox();
        textdata.Name = "TextData";
        textdata.Width = 200;
        textdata.Height = 50;
        textdata.Location = new Point(20, 20);
        SampleForm.Controls.Add(textdata);
    }
    
    private static void GetButtons(Form SampleForm)
    {
        Button ShowMsg = new Button();
        ShowMsg.Name = "ShowMsg";
        ShowMsg.Text = "Show TextBox Message";
        ShowMsg.Width = 100;
        ShowMsg.Location = new Point(100, 100);
        SampleForm.Controls.Add(ShowMsg);
        ShowMsg.Click += new EventHandler(ShowMsg_click);
    }
    
    private static void ShowMsg_click (object sender, EventArgs e)
    {
        var ShowMsg = (Button)sender;
        var SampleForm = ShowMsg.FindForm();
        foreach (Control elements in SampleForm.Controls)
        {
            if (elements.GetType() == typeof(TextBox))
            {
                MessageBox.Show(elements.Text.ToString());
            }
        }
    }
