    Rectangle rect = new Rectangle();
    rect.Height = 69;
    rect.Fill = new SolidColorBrush(Colors.Gray);
    rect.Margin = new Thickness(0, 95, 0, 0);
    rect.VerticalAlignment = VerticalAlignment.Top;
    list_grid.Children.Add(rect);
    TextBlock question_textblock = new TextBlock();
    question_textblock.Text = question;
    question_textblock.Margin = new Thickness(10, 103, 10, 0);
    question_textblock.FontWeight = FontWeights.Bold;
    list_grid.Children.Add(question_textblock);
    TextBlock answer_textblock = new TextBlock();
    answer_textblock.Text = question;
    answer_textblock.Margin = new Thickness(10, 124, 10, 0);
    list_grid.Children.Add(answer_textblock);
            
    list_grid.UpdateLayout();
