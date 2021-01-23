        private List<DisplayText> textsToDisplay = new List<DisplayText>();
        public void DisplayText( DisplayText t )
        {
            if (textsToDisplay.Contains( t ))
                return;
            textsToDisplay.Add( t );
            Invalidate();
        }
        protected override void OnPaint( PaintEventArgs e )
        {
            foreach (DisplayText t in textsToDisplay)
                e.Graphics.DrawString( t.Text, t.Font, t.Brush, t.Point );
            base.OnPaint( e );
        }
