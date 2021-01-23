      private void Menu1_Click(object sender, RoutedEventArgs e)
        {      
            MdiChild newForm = new MdiChild();
        newForm .Title = "My Form";
        newForm .Content = new MyForm1();
        newForm .Width = 500;
        newForm .Height = 400;
        newForm .Resizable = false;
        newForm .MaximizeBox = false;
   
        Container.Children.Add(newForm);
        // And then I add the position:
       Point centerPoint = new Point((Container.ActualWidth / 2) - (newForm .Width / 2), (Container.ActualHeight / 2) - (newForm .Height / 2));
       newForm .Position = centerPoint;
        }
