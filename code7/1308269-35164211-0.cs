    public class Person
    {
        public double WritingFontSize { get; set; }
        public ObservableCollection<double> FontSizeItemsSource
        {
            get
            {
                ObservableCollection<double> sizes = new ObservableCollection<double>();
                // Items generation could be made here
                sizes.Add(5.0);
                sizes.Add(5.5);
                return sizes;
            }
        }
    }
        <xctkpg:PropertyGrid SelectedObject="{Binding MyPersonObject}" AutoGenerateProperties="False">
            <xctkpg:PropertyGrid.EditorDefinitions>
                <xctkpg:EditorTemplateDefinition TargetProperties="WritingFontSize">
                    <xctkpg:EditorTemplateDefinition.EditingTemplate>
                        <DataTemplate>
                            <ComboBox ItemsSource="{Binding Instance.FontSizeItemsSource}" SelectedValue="{Binding Instance.WritingFontSize}" />
                        </DataTemplate>
                    </xctkpg:EditorTemplateDefinition.EditingTemplate>
                </xctkpg:EditorTemplateDefinition>
            </xctkpg:PropertyGrid.EditorDefinitions>
        
            <xctkpg:PropertyGrid.PropertyDefinitions>
                <xctkpg:PropertyDefinition TargetProperties="WritingFontSize" />
            </xctkpg:PropertyGrid.PropertyDefinitions>
        </xctkpg:PropertyGrid>
