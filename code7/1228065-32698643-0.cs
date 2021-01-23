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
                for(int i = 0; i < formList.Count; i++)
                {
                    string thisForm= formList[i];
                    if (thisForm == name)
                    { formList.RemoveAt(i); }
                }
                if (formList.Count == 0)
                { Application.Exit(); }
            }
