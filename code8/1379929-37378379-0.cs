    private void openToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ark = new OpenFileDialog();
            ark.Filter = "ARK Map (*.ark)|*.ark";
            int p = 0;
            if (ark.ShowDialog() == DialogResult.OK)
            {
                List<string> findings = new List<string>();
                for (int i = 0; i < 15; i++)
                {
                    findings.Add(string.Format("{0}-{1}", Tamed_Dino(ark.FileName, Dino_Tamer, 37)[i], Tamed_Dino(ark.FileName, Dino_Name, 35)[i]));
                }
                List<string> tamerList = new List<string>();
                foreach (string tamerDino in findings)
                {
                    string tamerName = tamerDino.Split('-')[0].Trim();
                    if (!tamerList.Contains(tamerName))
                    {
                        tamerList.Add(tamerName);
                        Console.WriteLine(tamerName);
                    }
                }
                for (int l = 0; l < tamerList.Count; l++)
                {
                    string title = tamerList[l];
                    TabPage tabPage = new TabPage(title);
                    multi_prof.TabPages.Add(title);
                    Panel np = new Panel();
                    np.BorderStyle = BorderStyle.None;
                    np.Location = new Point(10, 10);
                    np.Dock = DockStyle.Fill;
                    np.Name = tamerList[l];
                    multi_prof.SelectedIndex = l;
                    multi_prof.SelectedTab.Invoke((Action)(() => multi_prof.SelectedTab.Controls.Add(np)));
                    foreach (string tamer in tamerList)
                    {
                        List<string> fullDinosForTamer = findings.Where(r => r.StartsWith(tamer)).ToList();
                        //Populate your panel with the newly found dinos
                        Label lbl;
                        p = 0;
                        for (int i = 0; i < fullDinosForTamer.Count; i++)
                        {
                            if (fullDinosForTamer[i].StartsWith(tamerList[l]))
                            {
                                lbl = new Label();
                                lbl.Text = fullDinosForTamer[i].Split('-')[1];
                                lbl.Name = fullDinosForTamer[i];
                                lbl.AutoSize = true;
                                lbl.Location = new Point(10, p * 20);
                                np.Invoke((Action)(() => np.Controls.Add(lbl)));
                                p++;
                            }
                        }
                    }
                }
            }
        }
