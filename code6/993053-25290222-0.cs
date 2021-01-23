    if (((FrameworkElement)e.Source).GetType()== typeof(System.Windows.Controls.TabControl))
      {
       if (item1.IsSelected)
            {
                myllist1.DataContext = getList1();
            }
            else if (item2.IsSelected)
            {
                mylist2.DataContext = getlist2();
            }
            else if (item3.IsSelected)
            {
                mylist3.DataContext = getlist3();
            }
            else if (item4.IsSelected)
            {
                mylist4.DataContext = getlist4();
            }
      }
