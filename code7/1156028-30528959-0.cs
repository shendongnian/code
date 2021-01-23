     //extending the picture box
    public  class PicControl : PictureBox
        {
            // variables to save the picture box old position
            private int _OldWidth;
            private int _OldHeight;
            private int _OldTop;
            private int _OldLeft;
            public PicControl()
            {
            }
    
            protected override void OnMouseHover(EventArgs e)
            {
                 //once mouse enters 
                  // take the backup of height width top left
                 //so we can restore once mouse leaves
                _OldTop = this.Top;
                _OldLeft = this.Left;
                _OldWidth = this.Width;
                _OldHeight = this.Height;
                //decrease the control top left to show hover effect
                this.Top = this.Top - 10;
                this.Left = this.Left - 10;
                // same increase the height width
                this.Height = this.Height + 20;
                this.Width = this.Width + 20;
                //trigger the base event
                base.OnMouseHover(e);
            }
            protected override void OnMouseLeave(EventArgs e)
            {
                   // mouse leaves now we have to restore 
                  //picture box to its original position
                this.Height = _OldHeight;
                this.Width = _OldWidth;
                this.Left = _OldLeft;
                this.Top = _OldTop;
                base.OnMouseLeave(e);
            }
        }
