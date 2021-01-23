    private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
                {
    
                    string installerfilename = path + "installer.ini";
                    string installertext = File.ReadAllText(installerfilename);
                    var lin = File.ReadLines(path + "installer.ini").ToArray();
    
                    if(this.ActiveControl != sender )
                        return;
                    CheckBox cb = sender as CheckBox;
                    if ((cb.Checked)
                    {
                                     //  checkBox1.Checked = false;
                        for (int i = 0; i < this.checkedListBox2.Items.Count; i++)
                            {
                                this.checkedListBox2.SetItemChecked(i, true)                    
                            }
                        foreach (var txt in lin)
                        {
                            if (txt.Contains("#product="))
                            {
                                // var name = txt.Split('=')[1];
                                installertext = installertext.Replace("#product=", "product=");
                            }
                            File.WriteAllText(installerfilename, installertext);
                        }
                    }
                    else 
                    {
                        //checkBox1.Checked = false;
                        for (int i = 0; i < this.checkedListBox2.Items.Count; i++)
                        {
                            this.checkedListBox2.SetItemChecked(i, false);                            
                        }
                        foreach (var txt in lin)
                        {
                            if (txt.Contains("product=") && (!txt.StartsWith("#")))
                            {
                                // var name1 = txt.Split('=')[1];
                                installertext = installertext.Replace(txt, "#" +txt);
                            }
                            File.WriteAllText(installerfilename, installertext);
                        }
                    }
    
                }
