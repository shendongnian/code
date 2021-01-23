    private void btnAdd_Click(object sender, RoutedEventArgs e)
            {
                TestItemList.Add(new TestItem());
                gvTest.ItemsSource = TestItemList;
            }
