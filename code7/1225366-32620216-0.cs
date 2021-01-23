        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //New panel you can create like you want it
                    //It's important to set AllowDrop = true!
                    Panel p = new Panel
                    {
                        Top = j * Height / 8 - 5,
                        Left = i * Width / 8 - 5,
                        Size = new Size(Width / 8, Height / 8),
                        Margin = Padding.Empty,
                        Padding = Padding.Empty,
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
