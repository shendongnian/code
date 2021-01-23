     Control c = new Button();
     c.Text = "hello";
     if (c.GetType() == typeof(Button))
     {
         Button button = c as Button;
         MessageBox.Show(button.Text);
     }
