        protected override void OnLoad(EventArgs e) {
            var area = Screen.AllScreens.Length > 1 ? Screen.AllScreens[1].WorkingArea : Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point((area.Width - this.Width) / 2, (area.Height - this.Height) / 2);
            base.OnLoad(e);
        }
