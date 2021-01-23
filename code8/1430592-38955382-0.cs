    private void button_Click(object sender, RoutedEventArgs e)
    	{
            Model model = new Model();
    	    model.Property1 = textBox1.Text;
            model.Property2 = textBox2.Text;
    
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
    	}
