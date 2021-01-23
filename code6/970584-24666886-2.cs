	//this is critical to wire up the "Window.Current.CoreWindow.CharacterReceived" event when 
	//the textBox get focus and to unwire it when the textBox lose focus.
	// notice that the whole page is listening not only the textBox
		
        private void txtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.CharacterReceived += inputEntered;
        }
        private void txtBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.CharacterReceived -= inputEntered;
        }
		
		
		
	// temporary variable for holding the latest textBox value before the textChange event is trigerred
        string txtTemp = "";
		
        private void txtBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
			//whenever a key is pressed, capture the latest textBox value
            txtTemp= txtBox.Text;
        }
	// this boolean is to be used by the textChanged event to decide to accept changes or not
        bool acceptChange = true;
	// here we recieve the character and decide to accept it or not.
        private void inputEntered(CoreWindow sender, CharacterReceivedEventArgs args)
        {
		// reset the bool to true in case it was set to false in the last call
            acceptChange = true;
            
            Debug.WriteLine("KeyPress " + Convert.ToChar(args.KeyCode)+ "keyCode = "+ args.KeyCode.ToString());
            args.Handled = true;
			
		//in my case I needed only numeric value and the backSpace button 
            if ((args.KeyCode > 47 && args.KeyCode < 58) || args.KeyCode == 8)
            {
                //do nothing (i.e. acceptChange is still true)
            }
            else
            {
		//set acceptChange to false bec. character is not numeric nor backSpace
                acceptChange = false;
            }
        }
		
		
        private void txtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
		//the code here is my validation where I want only 3 digits number with no decimal
            if (txtBox.Text.Length < 4)
            {
                if (acceptChange)
                {
			// do nothing
                }
                else
                {
                    txtBox.Text = txtTemp;
					
			//this is to move the cursor to the end of the text in the textBox
                    txtBox.Select(txtBox.Text.Length, 0);
                }
            }
            else
            {
                txtBox.Text = txtTemp;
				
			//this is to move the cursor to the end of the text in the textBox
                txtBox.Select(txtBox.Text.Length, 0);
            }
            
			
        }
       
		
       
	// this is for the special case where the user input text using Paste function
        private void txtBox_Paste(object sender, TextControlPasteEventArgs e)
        {
            e.Handled=true;
        }
 
