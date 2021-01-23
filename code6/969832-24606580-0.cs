    private void ApplicationBarIconButton_Click(object sender, EventArgs e)
    {
        	BindingExpression expression = TitleTB.GetBindingExpression(TextBox.TextProperty);
        	MessageBox.Show("Before UpdateSource, Test = " + M1.Title);
        	expression.UpdateSource();
        	MessageBox.Show("After UpdateSource, Test = " + M1.Title);
    }
