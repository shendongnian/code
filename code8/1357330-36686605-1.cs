     <Storyboard x:Name="Storyboard1">
                <ColorAnimation  Storyboard.TargetProperty="(ListViewItem.Foreground).(SolidColorBrush.Color)" From="Red" To="YellowGreen" Duration="0:0:0.2"
                                            AutoReverse="True" RepeatBehavior="Forever"/>
            </Storyboard>
     ListViewItem item;
            private void button_Click(object sender, RoutedEventArgs e)
            {
                listView.Items.Add(textBox.Text);
                listView.UpdateLayout();
             item =  (ListViewItem) listView.ContainerFromIndex(listView.Items.Count-1);
                manip();
            }
    
        private void T_Tick(object sender, object e)
                {
                    if (item != null)
                    {
                      Storyboard1.Stop();//If animation is running for previously added item
                      Storyboard.SetTarget(Storyboard1, item);
                      Storyboard1.Begin();
                        t.Stop();
                    }
                }
