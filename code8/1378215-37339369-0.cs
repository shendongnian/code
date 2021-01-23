      string s = string.Empty, NewLine = string.Empty; ;
                        System.IO.StreamReader MyStreamReader=new System.IO.StreamReader(clientSocket.GetStream(), System.Text.Encoding.UTF8);
                        while((NewLine=MyStreamReader.ReadLine())!=null)
                            s+=NewLine+"\r\n";
                        MyStreamReader.Close();
