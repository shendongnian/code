    <Grid>
        <TabControl KeyDown="TabControl_KeyDown">
            <TabItem Header="Item1">
                <TextBlock Text="Content1"/>
            </TabItem>
            <TabItem Header="Item2">
                <TextBlock Text="Content2"/>
            </TabItem>
            <TabItem Header="Item3">
                <TextBlock Text="Content3"/>
            </TabItem>
        </TabControl>
    </Grid>
    ....
    private void TabControl_KeyDown(object sender, KeyEventArgs e)
    {
         if (e.Key == Key.Tab)
         {
             TabControl ctrl = (TabControl)sender;
             var currentSelected = ctrl.SelectedIndex;
             if (currentSelected == (ctrl.Items.Count - 1))
             {
                 ctrl.SelectedIndex = 0;
             }
             else
             {
                 ctrl.SelectedIndex = currentSelected += 1;   
             }
         }
     }
