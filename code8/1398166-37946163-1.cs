    TcpClient client = new TcpClient(serverIP, 11000);
    NetworkStream stream = client.GetStream();
    Byte[] bytes = new Byte[256];
    String data = null;
    int i;
    
    stream.Write(copy, 0, copy.Length);
    
    bool isFinished = false;
    
    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
    {
        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
        //MessageBox.Show(data);
        switch (data)
        {
            case "Completed":
                isFinished = true;
                this.Invoke((MethodInvoker)delegate
                {
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;
                    progressBar1.Update();
                    if (prod)
                    {
                        sqlLink.setProdFile(imageName, destFileName);
                    } else
                    {
                        sqlLink.setTestFile(imageName, destFileName);
                        if (sqlLink.getTestVM(imageName) != "")
                        {
                            if (message.Text("Test VM", "Power on specified Virtual Machine in private mode?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                PS ps = new PS();
                                ps.powerOnVM(sqlLink.getTestVM(imageName));
                            }
                        }
                    }
                    //Tried putting break; here.                            
                });
                break;
            case "FIU":
                {
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;
                    progressBar1.Update();
                    message.Text("Error", "The image is in use. Try shutting down machines or unassigning devices.", MessageBoxButtons.OK);
                }
                break;
            case "DSF":
                {
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;
                    progressBar1.Update();
                    message.Text("Error", "Drive space is full on production volume. Try deleting some older images.", MessageBoxButtons.OK);
                }
                break;
            default:
                this.Invoke((MethodInvoker)delegate
                {
                    progressBar1.Value = Int16.Parse(data);
                    progressBar1.Update();
                });
                break;
        }
        if(isFinished)
        {
            break;
        }
     }
        MessageBox.Show("this happens");
        stream.Close();
        client.Close();
    }
    catch (Exception ex)
    {
        message.Text("Error", "Copy Method Error: " + ex.Message, MessageBoxButtons.OK);
    }
