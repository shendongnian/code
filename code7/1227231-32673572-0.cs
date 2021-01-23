    StreamReader Read2;
        Read2 = File.OpenText("save" + campionatoselezTxt.Text + "bex.txt");
        StreamWriter Write2 = File.CreateText("read" + campionatoselezTxt.Text + "bex.txt");
        while (!Read2.EndOfStream)
        {
            string NewLine = "";
            for (int K = 0; K < 8; K++)
            {
                if (K != 0)
                    NewLine = NewLine  + ";" + Read2.ReadLine();
                else
                    NewLine = Read2.ReadLine();               
            }
            
             if(NewLine.Contains("Specific Word"))
                    break;
            Write2.WriteLine(NewLine);
        }
        Read2.Close();
        Write2.Close();
