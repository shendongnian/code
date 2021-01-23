      private void buttonSave_Click(object sender, EventArgs e)
            {
                if (selectedFileInfo != null)
                {
                    FileStream stream = null;
    
                    try
                    {
                        stream = selectedFileInfo.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                        using (StreamWriter sw = new StreamWriter(stream))
                        {
                            sw.AutoFlush = true;
                            sw.Write(scintilla1.Text);
                            sw.Flush();
                            sw.Close();
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (stream != null)
                            stream.Close();
                    }
                }
            }
