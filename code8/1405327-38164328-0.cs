    if (File.Exists(docs + @"\cfg.xml"))
                {
                    try
                    {
                        using (FileStream read = new FileStream(docs + @"\cfg.xml", FileMode.Open, FileAccess.Read, FileShare.Read)){
                            XmlSerializer xs = new XmlSerializer(typeof(Data));
                            Data info = (Data)xs.Deserialize(read);
                            signApkCheckBox.Checked = bool.Parse(info.Data1);
                            pathOfApk.Text = info.Data2;
                            pathOfDec.Text = info.Data3;
                            pathOfCom.Text = info.Data4;
                            disableDebugChkBox.Checked = bool.Parse(info.Data5);            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
