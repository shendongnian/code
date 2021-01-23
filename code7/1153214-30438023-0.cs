    Panel pnlTextBox;
    protected void Page_Load(object sender, EventArgs e)
    {
        Literal lt;
        Label lb;
        Button btnAddTxt = new Button();
        btnAddTxt.ID = "btnAddTxt";
        btnAddTxt.Text = "Add TextBox";
        btnAddTxt.Click += new System.EventHandler(btnAdd_Click);
        this.form1.Controls.Add(btnAddTxt);
        if (IsPostBack)
        {
            RecreateControls("txtDynamic", "TextBox");
        }
        
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
        Button btn = (Button)sender;
        if (btn.ID == "btnAddTxt")
        {
            // Can do database stuff here
            int cnt = FindOccurence("txtDynamic");
            TextBox txt = new TextBox();
            txt.ID = "txtDynamic-" + Convert.ToString(cnt + 1);
            pnlTextBox.Controls.Add(txt);
            Literal lt = new Literal();
            lt.Text = "<br />";
            pnlTextBox.Controls.Add(lt);
        }
    }
    private int FindOccurence(string substr)
    {
        string reqstr = Request.Form.ToString();
        return ((reqstr.Length - reqstr.Replace(substr, "").Length) / substr.Length);
    }
    private void RecreateControls(string ctrlPrefix, string ctrlType)
    {
        string[] ctrls = Request.Form.ToString().Split('&');
        int cnt = FindOccurence(ctrlPrefix);
        if (cnt > 0)
        {
            Literal lt;
            for (int k = 1; k <= cnt; k++)
            {
                for (int i = 0; i < ctrls.Length; i++)
                {
                    if (ctrls[i].Contains(ctrlPrefix + "-" + k.ToString()))
                    {
                        string ctrlName = ctrls[i].Split('=')[0];
                        string ctrlValue = ctrls[i].Split('=')[1];
                        //Decode the Value
                        ctrlValue = Server.UrlDecode(ctrlValue);
                        if (ctrlType == "TextBox")
                        {
                            TextBox txt = new TextBox();
                            txt.ID = ctrlName;
                            txt.Text = ctrlValue;
                            pnlTextBox.Controls.Add(txt);
                            lt = new Literal();
                            lt.Text = "<br />";
                            pnlTextBox.Controls.Add(lt);
                        }
                        break;
                    }
                }
            }
        }
    }
