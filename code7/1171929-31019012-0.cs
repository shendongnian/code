        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            TextBox textbox = new TextBox();
            CheckBox checkbox = new CheckBox(); 
            switch(clickedButton.Content.ToString())
            {
                case "Button1":
                    textbox = textbox1;
                    checkbox = checkBox1;
                    textbox.Text = "10";                    
                    break;
                case "Button2":
                    textbox = textbox2;
                    checkbox = checkBox2;
                    textbox.Text = "20";
                    break;
                case "Button3":
                    textbox = textbox3;
                    checkbox = checkBox3;
                    textbox.Text = "30";
                    break;
                default:
                    break;
            }
            checkbox.IsChecked = true; 
        }
