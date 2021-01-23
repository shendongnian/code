    if (Application.OpenForms.OfType<webForm>().Count() == 0)
                          ().First().Show();
                        {
                         webForm frm = new webForm();
                         frm.Show();
                         }
                        
                        Application.Run();
                    }
                    else
                    {
                        if (Application.OpenForms.OfType<webForm>().Count() == 1)
                        {
                            Form fc = Application.OpenForms["webForm"];
    
                            if (fc != null)
                                fc.Invoke(new MethodInvoker(delegate { fc.Close(); }));
               
    
             }
