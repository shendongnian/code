    for ( int i =0; i < formList.Count; i++)
            {
                    string formName = formList[i];
                    
                        Form1 frm = (new Form1(formName...);
                        frm.Show();
                        string contextName= formName;
                        frm.FormClosed += new FormClosedEventHandler((sender, e) => FrmClosed_Event(sender, e, contextName));                                     
            }
    
           public void FrmClosed_Event(object sender, FormClosedEventArgs e, string name)
            {
                foreach(string thisForm in origList)
                {
                    if (thisForm == name)
                    { formList.Remove(thisForm); }
                }
                if (formList.Count == 0)
                { Application.Exit(); }
            }
