    <Window x:Class="WpfApplication5.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:my="clr-namespace:WpfApplication5"
            Title="MainWindow" Height="300" Width="800" FontSize="25">
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition />
                <ColumnDefinition />
            </Grid.ColumnDefinitions>
            <TreeView SelectedItemChanged="TreeView_SelectedItemChanged">
                <TreeViewItem Header="A">
                    <TreeViewItem Header="AA">
                        <TreeViewItem Header="AAA"/>
                        <TreeViewItem Header="AAB"/>
                    </TreeViewItem>
                    <TreeViewItem Header="AB"/>
                </TreeViewItem>
                <TreeViewItem Header="B">
                    <TreeViewItem Header="BA"/>
                    <TreeViewItem Header="BB">
                        <TreeViewItem Header="BBA"/>
                        <TreeViewItem Header="BBB"/>
                    </TreeViewItem>
                </TreeViewItem>
            </TreeView>
            <StackPanel Grid.Column="1">
                <TextBlock Name="txt1"/>
                <TextBlock Name="txt2"/>
                <ListBox Name="lst" ></ListBox>
            </StackPanel>
        </Grid>
    </Window>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private object itm1;
        private object itm2;
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (itm1 == null || (itm1 != null && itm2 != null))
            {
                itm1 = e.NewValue;
                itm2 = null;
                txt1.Text = itm1.ToString();
                txt2.Text = "";
                return;
            }
            itm2 = e.NewValue;
            txt2.Text = itm2.ToString();
            var tree = sender as ItemsControl;
            firstFound = false;
            secondFound = false;
            between = new List<object>();
            checkCollection(tree);
            lst.Items.Clear();
            foreach (var itm in between)
            {
                lst.Items.Add(itm.ToString());
            }
        }
        bool firstFound = false;
        bool secondFound = false;
        List<object> between = new List<object>();
        private void checkCollection(object ctrl)
        {
            if (secondFound)
                return;
            if (!firstFound && (ctrl == itm1 || ctrl == itm2))
            {
                firstFound = true;
            }
            else if (firstFound && (ctrl == itm1 || ctrl == itm2))
            {
                secondFound = true;
                return;
            }
            if (firstFound)
            {
                between.Add(ctrl);
            }
            var itmsCtrl = ctrl as ItemsControl;
            foreach (var itm in itmsCtrl.Items)
            {
                checkCollection(itm);
            }
        }
    }
