        private int DynCheckBoxCount
        {
            get { return (int)this.ViewState["DynCheckBoxCount"]; }
            set { this.ViewState["DynCheckBoxCount"] = value; }
        }
        private void BuildCheckBoxes()
        {
            if (!this.IsPostBack)
            {
                int i = 0;
                foreach (string filename in filepaths)
                {
                    CheckBox chk = new CheckBox();
                    chk.Text = Path.GetFileName(filename); // Don't do a .ToString() on a string.  It's unnecessary, ugly code, and opens the door for NullReferenceExceptions.
                    chk.Style.Add(HtmlTextWriterStyle.Display, "block");
                    Panel1.Controls.Add(chk);
                    string key = string.Format("{0}_{1}", this.Session.SessionID, i++);
                    this.Page.Cache[key] = chk;
                }
                this.DynCheckBoxCount = i;
            }
            else
            {
                for (int i = 0; i < this.DynCheckBoxCount; i++)
                {
                    string key = string.Format("{0}_{1}", this.Session.SessionID, i);
                    CheckBox chk = (CheckBox)this.Page.Cache[key];
                    this.Panel1.Controls.Add(chk);
                }
            }
        }
