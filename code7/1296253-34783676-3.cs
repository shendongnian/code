            int top = 50;
            int left = 100;
            var buttons = new Dictionary<string, Button>();
            for (int i = 0; i < 30; i++)
            {
                Button button = new Button();
                buttons.Add("B"+i, button);
                button.Left = left;
                button.Top = top;
                this.Controls.Add(button);
                top += button.Height + 2;
                button.BackColor = Color.Red;
            }
