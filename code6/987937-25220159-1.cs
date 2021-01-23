        private void button3_Click(object sender, EventArgs e)
        {
            List<string> rawhtml = new List<string>(); //List for the whole page
            List<string> list_pick = new List<string>(); //PICK section
            List<string> list_win = new List<string>(); //WIN section
            List<string> list_ban = new List<string>(); //BAN section
            List<string> list_Comp = new List<string>(); //Champion names
            fillchamplist(list_Comp);
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
                string rtbpicker = item.ToString();
                foreach (var comp in list_Comp)
                {
                    int count = 0; //To see which match we working with later
                    foreach (Match m in Regex.Matches(rtbpicker, "" + comp.ToString() + "")) // Checks for all matches and cycles through them
                    {
                        if (count == 2) // if the count == 2, it means that its on its 3rd match(the one we dont wana give a space to
                        {
                        }
                        else // puts the space in
                        {
                            int matchindex = m.Index;
                            int matchlength = m.Length;
                            if (m.Length >= 2) // only champ names are >=2
                            {
                                rtbpicker = rtbpicker.Insert(matchindex + matchlength + count, "\t"); 
                            }
                            else
                            {
                                rtbpicker = rtbpicker.Insert(matchindex + matchlength + count, " "); // the count variable updates he index so the space doesnt occur before the % sign
                            }
                            if (Regex.Matches(rtbpicker, "" + comp.ToString() + "").Count > 0)// just to update the index for the 2nd %
                            {
                                count++;
                            }
                        }
                    }
                }
                rtbPick.AppendText(rtbpicker + System.Environment.NewLine); //Optinal: Add to richtextbox
            }
            // WIN
            for (int i = ID_win; i < ID_win + (ID_ban - ID_win); i++)
            {
                list_win.AddRange(Regex.Split(rawhtml[i], "(?<=[)])"));
            }
            foreach (var item in list_win)
            {
                string rtbpicker = item.ToString();
                foreach (var comp in list_Comp)
                {
                    int count = 0;
                    foreach (Match m in Regex.Matches(rtbpicker, "" + comp.ToString() + ""))
                    {
                        if (count == 2)
                        {
                        }
                        else
                        {
                            int matchindex = m.Index;
                            int matchlength = m.Length;
                            if (m.Length >= 2)
                            {
                                rtbpicker = rtbpicker.Insert(matchindex + matchlength + count, "\t");
                            }
                            else
                            {
                                rtbpicker = rtbpicker.Insert(matchindex + matchlength + count, " ");
                            }
                            if (Regex.Matches(rtbpicker, "" + comp.ToString() + "").Count > 0)
                            {
                                count++;
                            }
                        }
                    }
                }
                rtbWin.AppendText(rtbpicker + System.Environment.NewLine);
            }
            // BAN
            for (int i = ID_ban; i < ID_ban + (ID_cmt - ID_ban); i++)
            {
                list_ban.AddRange(Regex.Split(rawhtml[i], "(?<=[)])"));
            }
            foreach (var item in list_ban)
            {
                string rtbpicker = item.ToString();
                foreach (var comp in list_Comp)
                {
                    int count = 0;
                    foreach (Match m in Regex.Matches(rtbpicker, "" + comp.ToString() + ""))
                    {
                        if (count == 2)
                        {
                        }
                        else
                        {
                            int matchindex = m.Index;
                            int matchlength = m.Length;
                            if (m.Length >= 2)
                            {
                                rtbpicker = rtbpicker.Insert(matchindex + matchlength + count, "\t");
                            }
                            else
                            {
                                rtbpicker = rtbpicker.Insert(matchindex + matchlength + count, " ");
                            }
                            if (Regex.Matches(rtbpicker, "" + comp.ToString() + "").Count > 0)
                            {
                                count++;
                               
                            }
                        }
                    }
                    
                }
                rtbBan.AppendText(rtbpicker + System.Environment.NewLine);
            }
        }
