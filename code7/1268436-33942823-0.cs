    int check=0;
    if (txt_uname.Text != "")
                {
                    check = 0;
                    System.IO.StreamReader file = new System.IO.StreamReader(path);
                    string[] columnnames = file.ReadLine().Split('\t');
                    string newline;
                    while ((newline=file.ReadLine()) != null)
                    {
                        string[] values = newline.Split('\t');
                        if (check== 0){
                            for (int i = 0; i < values.Length; i++)
                            {
                                if (txt_uname.Text == values[i] && txt_pw.Text == values[i + 1])
                                {
                                    Console.WriteLine("User found");
                                    check= 1;
                                    break;
    
                                }
                                else
                                {
                                    Console.WriteLine("User isn't exists");
    
                                }
                            }
                            
    
                        }
                        
                    }
    
                
