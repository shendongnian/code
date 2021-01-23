    foreach (string line in ticketLines)
                {   
                    if (line.Contains(searchkeys)) 
                    {
                        //daca se gaseste ce e in txtID se ia indexul liniei si il bag in txtTitle.text
                        int y = codes.IndexOf(line);
                        txtTitle.Text = codes[y+1].Substring(codes[y + 1].IndexOf(">") + 1, codes[y + 1].Length - codes[y + 1].IndexOf(">") - 6);
                        txtCreatedAt.Text = codes[y + 3].Substring(codes[y + 3].IndexOf(">") + 1, codes[y + 3].Length - codes[y + 3].IndexOf(">") - 6);
                        txtCreatedBy.Text = codes[y + 4].Substring(codes[y + 4].IndexOf(">") + 1, codes[y + 4].Length - codes[y + 4].IndexOf(">") - 6);
    
                        break;
                    }
    
    
                }
