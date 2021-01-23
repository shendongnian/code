        public GradientButton()
       {
            Color1 = Color.YellowGreen;
            Color2 = Color.LightGreen;
            Angle = 30;
            Paint += new PaintEventHandler(GradientButton_Paint);
        }
