    for (int i = 1; i < 3; i++)
            {
                var buttonName = "button" + i;
                Button button = this.Controls.Find(buttonName, true).FirstOrDefault() as Button;
                string text = button.Text;
            }
