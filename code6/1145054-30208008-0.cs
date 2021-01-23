    RichTextBox[] RichtextBoxes { get; set; }
            CheckBox[] Checkboxes { get; set; }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                int n = TodoItems.Count;
                 RichtextBoxes = new RichTextBox[n];
                 Checkboxes = new CheckBox[n];
                for (int i = 0; i < n; i++)
                {
                    //creating the richtextbox
                    RichtextBoxes[i] = new RichTextBox();
                    RichtextBoxes[i].Name = "TB-" + i.ToString();
                    RichtextBoxes[i].Text = TodoItems[i].ToString();
                    RichtextBoxes[i].Location = new System.Drawing.Point(130, (10 + (60 * i)));
                    RichtextBoxes[i].Size = new System.Drawing.Size(300, 50);
                    RichtextBoxes[i].Visible = false;
                    RichtextBoxes[i].ReadOnly = true;
                    RichtextBoxes[i].SelectionAlignment = HorizontalAlignment.Center;
                    RichtextBoxes[i].BackColor = Color.White;
                    TodoList.Controls.Add(RichtextBoxes[i]);
    
                    //creating the checkboxes
                    Checkboxes[i] = new CheckBox();
                    Checkboxes[i].Name = "CB-" + i.ToString();
                    Checkboxes[i].Text = "";
                    Checkboxes[i].Location = new System.Drawing.Point(440, (30 + (60 * i)));
                    Checkboxes[i].Size = new System.Drawing.Size(18, 17);
                    Checkboxes[i].Visible = true;
                    Checkboxes[i].CheckedChanged += checkBox1_CheckedChanged;
                    TodoList.Controls.Add(Checkboxes[i]);
                }
            }
    
            void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
                CheckBox cb = sender as CheckBox;
    
                string cbName = cb.Name;
                int sbNumber = int.Parse(cbName.Split('-')[1]);
    
                RichtextBoxes[sbNumber].Visible = true; // you can get desired richtextbox here and can any thing with it :)
    
    
            }
