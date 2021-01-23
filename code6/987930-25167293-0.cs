            private void button_Click(object sender, EventArgs e)
        {
            List<string> rawhtml = new List<string>(); //List for the whole page
            List<string> list_pick = new List<string>(); //PICK section
            List<string> list_win = new List<string>(); //WIN section
            List<string> list_ban = new List<string>(); //BAN section
            rawhtml = richTextBox1.Lines.ToList(); //FILL the page to list
            int ID_pick = 0;
            int ID_win = 0;
            int ID_ban = 0;
            int ID_cmt = 0; // We need to specify the end of BAN section
            for (int i = 0; i < rawhtml.Count; i++) //Search for the line number of section-start
			{
			    if (rawhtml[i] == "Champion Pick Rates") ID_pick = i;
                if (rawhtml[i] == "Champion Win Rates") ID_win = i;
                if (rawhtml[i] == "Champion Ban Rates") ID_ban = i;
                if (rawhtml[i].Contains("Comments")) ID_cmt = i;
			}
            // PICK
            for (int i = ID_pick; i < ID_pick + (ID_win - ID_pick); i++) //Calculate the start and the end line-number
            {
                list_pick.AddRange(Regex.Split(rawhtml[i], "(?<=[)])")); //Split the five characters, without losing the ')'
            }
            foreach (var item in list_pick)
            {
                richTextBox2.AppendText(item + System.Environment.NewLine); //Optinal: Add to richtextbox
            }
            // WIN
            for (int i = ID_win; i < ID_win + (ID_ban - ID_win); i++)
            {
                list_win.AddRange(Regex.Split(rawhtml[i], "(?<=[)])"));
            }
            foreach (var item in list_win)
            {
                richTextBox3.AppendText(item + System.Environment.NewLine);
            }
            // BAN
            for (int i = ID_ban; i < ID_ban + (ID_cmt - ID_ban); i++)
			{
			    list_ban.AddRange(Regex.Split(rawhtml[i], "(?<=[)])"));
			}
            foreach (var item in list_ban)
            {
                richTextBox4.AppendText(item + System.Environment.NewLine);
            }
        }
