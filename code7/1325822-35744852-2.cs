        private string StringHeaderTemplate = @"<DataTemplate>
       <Grid Background=""Transparent"">
            <i:Interaction.Triggers>
             <i:EventTrigger EventName=""MouseLeftButtonDown"">
               <si:CallMethodAction MethodName = ""Grid_MouseLeftButtonDown"" TargetObject=""{Binding RelativeSource={RelativeSource AncestorType=Window}}""/>
             </i:EventTrigger>
            </i:Interaction.Triggers>
            <Grid.RowDefinitions>
              <RowDefinition/>
              <RowDefinition/>
              <RowDefinition/>
          </Grid.RowDefinitions>
          <Button Content=""Hello""/>
          <TextBlock Grid.Row=""1"" HorizontalAlignment= ""Center"" Text = ""TextBlock"" />
          <CheckBox Grid.Row= ""2"" HorizontalAlignment= ""Center"" IsChecked= ""True"" />
       </Grid >    
    </DataTemplate>";
        public void Grid_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString());
        }
        private DataTemplate GetDatatemplate(string fromstring)
        {
            ParserContext context = new ParserContext();
            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            context.XmlnsDictionary.Add("i", "clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity");
            context.XmlnsDictionary.Add("si", "clr-namespace:Microsoft.Expression.Interactivity.Core;assembly=Microsoft.Expression.Interactions");
            return (DataTemplate)XamlReader.Parse(fromstring, context);
        }
