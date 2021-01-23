        private void Form1_Load(object sender, EventArgs e)
        {
            int boardSize = 500;
            this.ClientSize = new Size(boardSize + 2, boardSize + 2);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //New panel you can create like you want it
                    //It's important to set AllowDrop = true!
                    Panel p = new Panel
                    {
                        Top = j * boardSize / 8,
                        Left = i * boardSize / 8,
                        Size = new Size(boardSize / 8 + 2, boardSize / 8 + 2),
                        AllowDrop = true,
                        BorderStyle = BorderStyle.FixedSingle,
                    };
                    //This event will start DragDrop events
                    p.MouseDown += (o, args) => ((Form)sender).DoDragDrop("", DragDropEffects.None);
                    //Now you can change color of particual Panel
                    p.DragOver += (o, args) => p.BackColor = Color.Blue;
                    Controls.Add(p);
                }
            }
        }
