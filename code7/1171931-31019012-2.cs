        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            switch(clickedButton.Content.ToString())
            {
                case "Button1":
                    textbox1.Text = "10";
                    checkbox1.IsChecked = true;                                        
                    break;
                case "Button2":
                    textbox2.Text = "20";
                    checkbox2.IsChecked = true;
                    break;
                case "Button3":
                    textbox3.Text = "30";
                    checkbox3.IsChecked = true;                    
                    break;
                default:
                    break;
            }
        }
