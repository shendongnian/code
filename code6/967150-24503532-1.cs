     for (int i = 0; i < ClientLabel.Length; i++)
       {    
            // Web browsers
            WebBrowser wb = new WebBrowser()
            {
                ScrollBarsEnabled = false,
                Height = 12,
                Width = 12,
                Location = new Point(2 + WBoffsetX, 2 + WBoffsetY),
                ScriptErrorsSuppressed = true
            };
                       
            WBoffsetX += 13;
            Clients[i] = wb;
        
            // Labels
            Label label = new Label()
            {
                Name = "label_" + i,
                Text = "Data",
                AutoSize = true,
                Location = new Point(50 + lbloffsetX, 50 + lbloffsetY),
                Width = 100,
                Height = 20,
                Font = new Font("Arial", 12),
                ForeColor = System.Drawing.Color.White,
            };
        
            label.Click += new EventHandler(lbl_click);
            ClientLabel[i] = label;
            lbloffsetX += 30;
        }
        
        this.Controls.AddRange(Clients);
        this.Controls.AddRange(ClientLabel);
