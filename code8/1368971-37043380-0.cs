    /// <include file='DocumentationComments.xml' path='doc/members/member[@name="M:TwoLineListBox.OnPaint"]/*'/>
    		protected override void OnPaint(PaintEventArgs e)
    		{
    			base.OnPaint(e);
    			// draw on memory bitmap
    			CreateMemoryBitmap();
    
    			// TODO: Figure out how to avoid doing this on every paint
    			// calculate fields required to layout and draw list
    			RecalcItems(e.Graphics);
    
    			Graphics g = Graphics.FromImage(m_bmp);
    
    			// Draw the background and raise the PaintBackground event
    			OnPaintBackground(new ListPaintEventArgs(g));
    
    			// draw list
    			if (m_list != null)
    				DrawItems(g);
    
    			// Draw the frame around the list
    			Rectangle rc = new Rectangle(0, 0, this.Width - m_scrollBarWidth, this.Height - 1);
    			g.DrawRectangle(new Pen(Color.Black), rc);
    
    			// blit memory bitmap to screen
    			e.Graphics.DrawImage(m_bmp, 0, 0);
    		}
    
    		// This prevents the base class from doing OnPaintBackground.
    		// Since the OnPaint method paints the entire window there's no reason
    		// to let this go through. If we do it'll cause flashing.
    		/// <include file='DocumentationComments.xml' path='doc/members/member[@name="M:TwoLineListBox.OnPaintBackground"]/*'/>
    		protected override void OnPaintBackground(PaintEventArgs e)
    		{
    		}
    
    		// Called when it is time to draw the background. To take complete control of background
    		// drawing override this. To get called after the background is drawn by the base class
    		// register for the PaintBackground event.
    		/// <include file='DocumentationComments.xml' path='doc/members/member[@name="M:TwoLineListBox.OnPaintBackgroundII"]/*'/>
    		protected virtual void OnPaintBackground(ListPaintEventArgs e)
    		{
    			// Fill the background with the background colour
    			e.Graphics.Clear(this.BackColor);
    			if (PaintBackground != null)
    				PaintBackground(this, e);
    		}
    
    		// Called to draw a line item. To take complete control of drawing an item override this method.
    		// To let the base class draw the item first and then do your own additional work register for the
    		// PaintItem event.
    		/// <include file='DocumentationComments.xml' path='doc/members/member[@name="M:TwoLineListBox.OnPaintItem"]/*'/>
    		protected virtual void OnPaintItem(ListPaintEventArgs e)
    		{
    
    			Graphics g = e.Graphics;
    			Rectangle destRect = new Rectangle();	// Destination for the item image, if any
    			Rectangle srcRect = new Rectangle();	// Source region of the image to draw
    			Rectangle textRect = new Rectangle();	// Destination for the text
    			int lineIndent = 0;						// How far the text is moved in from the left margin before drawing
    			Image imageToDraw = null;
    			string line1Text;
    			string line2Text;
    
    			// On the null case skip everything and just draw the separator line
    			if (e.Item == null)
    				goto DrawSeparator;
    
    
    			line1Text = GetStringProperty(e.Item, this.m_line1Property);
    			if (line1Text == null)
    				line1Text = e.Item.ToString();
    
    			line2Text = GetStringProperty(e.Item, this.m_line2Property);
    			if (line2Text == null)
    				line2Text = e.Item.ToString();
    
    
    			// Figure out if we're drawing an image per item from the object, or one for
    			// everything
    			imageToDraw = GetImageProperty(e.Item, this.m_itemImageProperty);
    			if (imageToDraw == null)
    
    				imageToDraw = m_itemImage;
    
    			// Calculate the position of the item image, if we have one, and the line indents
    			if (imageToDraw != null)
    			{
    
    				srcRect.X = 0;
    				srcRect.Y = 0;
    				srcRect.Width = imageToDraw.Width;
    				srcRect.Height = imageToDraw.Height;
    
    				// int vertPos = (m_itemHeight - m_itemImage.Height) / 2;
    				destRect.X = e.ClipRectangle.X + IMAGE_PADDING_X;
    				destRect.Y = e.ClipRectangle.Y + IMAGE_PADDING_Y;
    				// destRect.Y = (vertPos < 0) ? 0 : vertPos;	// Center the image vertically in the line height. Handle the image being larger than the item height
    
    				// Account for an image that is taller than the item height
    				destRect.Height = (imageToDraw.Height > m_itemHeight - IMAGE_PADDING_Y) ? m_itemHeight - (IMAGE_PADDING_Y * 2) : imageToDraw.Height;
    				destRect.Width = destRect.Height;
    				// Set the text indent based on the image
    				lineIndent = IMAGE_PADDING_X + imageToDraw.Width + TEXT_PADDING_X;	// Two pixels for the left indent of the image
    			}
    			else
    			{
    				// Set the text indent without using the image
    				lineIndent = TEXT_PADDING_X;
    			}
    
    			// Calculate the text rectangle
    			textRect.X = e.ClipRectangle.X + lineIndent;
    			textRect.Width = e.ClipRectangle.Width - TEXT_PADDING_X - textRect.X;	// Allows for padding on the right edge too
    			textRect.Y = e.ClipRectangle.Y + 2;
    			textRect.Height = this.m_textHeightLine1;
    
    			// From here on we actually draw things. First the selected background, if necessary
    			if (e.Selected)
    				g.FillRectangle(m_brushSelBack, e.ClipRectangle);
    
    			// Draw the icon, if we have one
    			if (imageToDraw != null)
    			{
    				if (m_useTransparent)
    
    					g.DrawImage(imageToDraw, destRect, srcRect.Y, srcRect.Y, srcRect.Height, srcRect.Height,
    						GraphicsUnit.Pixel, m_imageAttributes);
    				else
    					g.DrawImage(imageToDraw, destRect, srcRect, GraphicsUnit.Pixel);
    			}
    
    			// Draw the text in a bounding rect to force it to truncate if too long
    			g.DrawString(line1Text, m_fontLine1, e.Selected ? m_brushSelText : m_brushText, textRect);
    
    			// Draw the second line
    			textRect.Y += m_textHeightLine1 + 3;
    			textRect.Height = this.m_textHeightLine2;
    			g.DrawString(line2Text, m_fontLine2, e.Selected ? m_brushSelText : m_brushText, textRect);
    
    		DrawSeparator:
    			// Draw the separator line
    			g.DrawLine(m_penSep, e.ClipRectangle.X, e.ClipRectangle.Y + e.ClipRectangle.Height,
    				e.ClipRectangle.X + e.ClipRectangle.Width, e.ClipRectangle.Y + e.ClipRectangle.Height);
    
    			// Let other people know it's time for them to draw
    			if (PaintItem != null)
    				PaintItem(this, e);
    		}
    
    
    		// Draw all the items.
    		private void DrawItems(Graphics g)
    		{
    			ListPaintEventArgs ListPaintEventArgs = new ListPaintEventArgs(g);
    
    			// Calculate our actual drawing area, accounting for the scroll bar
    			Rectangle rc = new Rectangle(0, 0, this.Width - m_scrollBarWidth, this.Height - 1);
    
    			// draw items that are visible
    			int curItem = 0;
    			for (int i = 0; (i < m_visibleCount); i++)
    			{
    				curItem = i + m_topItem;
    				if (curItem < m_list.Count)
    				{
    					// Calculate the drawing area for the item 
    					ListPaintEventArgs.ClipRectangle = new Rectangle(rc.X,
    						rc.Y + (i * m_itemHeight),
    						rc.Width,
    						this.m_itemHeight);
    
    					// Get the item we'll be drawing with and whether it is selected					
    					ListPaintEventArgs.Item = m_list[curItem];
    					ListPaintEventArgs.Selected = (m_selItem == curItem);
    
    					// Draw the item
    					OnPaintItem(ListPaintEventArgs);
    				}
    			}
    		}
    
    		// Recalculates the heights and visible counts for assorted items
    		// in the listbox.
    		// TODO: Get rid of this method by moving the rest of the items into the assorted
    		// properties.
    		private void RecalcItems(Graphics g)
    		{
    			// The text heights for a single line of text is the height of the font.
    			m_textHeightLine1 = g.MeasureString("W", this.m_fontLine1).ToSize().Height;
    			m_textHeightLine2 = g.MeasureString("W", this.m_fontLine2).ToSize().Height;
    
    			// The height for an individual item is two lines plus some padding
    			m_itemHeight = m_textHeightLine1 + m_textHeightLine2 + 5;
    
    			m_visibleCount = this.Height / m_itemHeight;
    
    			// Set the top item to draw to the current scroll position
    			m_topItem = m_scrollValue;
    		}
    
    		// Creates all the objects we need for drawing
    		private void CreateGdiObjects()
    		{
    			m_brushText = new SolidBrush(this.ForeColor);
    			m_brushSelText = new SolidBrush(this.m_selForeColor);
    			m_brushSelBack = new SolidBrush(this.m_selBackColor);
    			m_penSep = new Pen(this.m_separatorColor);
    			m_imageAttributes = new ImageAttributes();
    		}
    
    		// Creates a bitmap in memory to do our drawing. We'll draw on this first
    		// and then splat it to the screen.
    		private void CreateMemoryBitmap()
    		{
    			// Only create if don't have one and the size hasn't changed
    			if (m_bmp == null || m_bmp.Width != this.Width || m_bmp.Height != this.Height)
    			{
    				m_bmp = new Bitmap(this.Width - m_scrollBarWidth, this.Height);
    
    				// TODO: Figure out why this is here.
    				m_scrollBar.Left = this.Width - m_scrollBarWidth;
    				m_scrollBar.Top = 0;
    				m_scrollBar.Width = m_scrollBarWidth;
    				m_scrollBar.Height = this.Height;
    			}
    		}
