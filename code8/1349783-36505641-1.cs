            List<Button> buttons = new List<Button>();
    	 	List<TextBox> textboxes = new List<TextBox>();
    	 	
    		Button button1 = new Button();
    		TextBox textBox1 = new TextBox();
    		
    		int x = 0;
    		int y = 0;
    
    		void click(object sender, EventArgs e)
    		{
    		
    			
    			var txt =  textboxes[Convert.ToInt32(((Button)sender).Tag)].Text;
    			MessageBox.Show(txt.ToString());
    
    		}
    				
    		void AddClick(object sender, EventArgs e)
    		{
    				
    				Button newButton = new Button();
    		        newButton.Click += click;
    		        newButton.Location = new Point(button1.Location.X, button1.Location.Y+25+x);
    		        x += 25;
    		        newButton.Tag = buttons.Count;
    
    				this.Controls.Add(newButton);
    				
    				buttons.Add(newButton);				
    				//
    				TextBox newTextBox = new TextBox();
    		        newTextBox.Location = new Point(textBox1.Location.X, textBox1.Location.Y+25+y);
    		        y += 25;
    				this.Controls.Add(newTextBox);
    				
    				textboxes.Add(newTextBox);
    				
    		}
    		void MainFormLoad(object sender, EventArgs e)
    		{
    				button1.Click += click; 
    		        button1.Location = new Point(55, 48);
    
    		        button1.Tag = buttons.Count;
    
    				this.Controls.Add(button1);
    				
    				buttons.Add(button1);				
    				//
    				textBox1.Location = new Point(137, 50);
    
    				this.Controls.Add(textBox1);
    				
    				textboxes.Add(textBox1);
    		}
