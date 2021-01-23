        private void CreateVerticalButtons()
        {
            const int LEFT = 200;
            var top = 50;
            var x = int.Parse(X.Text);
            var y = int.Parse(Y.Text);
            for (var i = 1; i <= y; i++)
            {
                for (var j = 1; j <= x; j++)
                {
                    var btn = new Button();
                    btn.Text = string.Format("{0}ff{1}", j, i);
                    btn.Height = 20; btn.Width = 50;
                    btn.Top = top;
                    btn.Left = LEFT;
                    top += 22;
                    this.Controls.Add(btn);
                }
            }
        }
        private void CreateHorizontalButtons()
        {
            const int TOP = 100;
            var left = 200;
            var x = int.Parse(X.Text);
            var y = int.Parse(Y.Text);
            for (var i = 1; i <= y; i++)
            {
                var top = TOP;
                for (var j = 1; j <= x; j++)
                {
                    var btn = new Button();
                    btn.Text = string.Format("{0}ff{1}", j, i);
                    btn.Height = 20; btn.Width = 50;
                    btn.Top = top;
                    btn.Left = left;
                    top -= 22;
                    this.Controls.Add(btn);
                }
                left += 52;
            }
        }
