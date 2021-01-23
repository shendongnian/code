     void CreateControl()
        {
            TimeSpan FifteenMinutes = new TimeSpan(0, 15, 0);
            TimeSpan Time = new TimeSpan(0,0,0);
            int i = 1;
            while (Time.Hours != 24)
            {
                Button btn1 = new Button();
                btn1.ID = "btn"+i;
                btn1.CommandArgument = i.ToString();
                btn1.Text = "click me";
                btn1.Click += new EventHandler(btn1_Click);
                div1.Controls.Add(btn1);
                Label lbl = new Label();
                lbl.Text = Time.ToString();
                div1.Controls.Add(lbl);
                Time = Time.Add(FifteenMinutes);
                i++;
            }
        }
