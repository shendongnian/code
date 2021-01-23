        bool labelRegistered = false;
        protected override void OnPaint( PaintEventArgs e )
        {
            int textStart = 0;
            SizeF ssize = new SizeF( 0, 0 );
            if (labelText != null && labelText != String.Empty) {
                ssize = e.Graphics.MeasureString( labelText, labelFont );
                textStart = (int)ssize.Width;
            }
    
           if (ssize.Width > 0) {
                if (this.TopLevelControl is IKindForm) {
                    if (!labelRegistered) {
                        int yPos = this.Location.Y + margin + ComboText.Size.Height / 4;
                        int xPos = this.Location.X - ( textStart + labelOffset );
                        ((IKindForm)this.TopLevelControl).DisplayText( new DisplayText(    labelText, LabelFont, labelColor,
                                                                                         xPos, yPos ) );
                    }
                }
                labelRegistered = true;
            }
