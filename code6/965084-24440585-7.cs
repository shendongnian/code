    public class PropertyGridInspectorVisualizer : DialogDebuggerVisualizer
    {
       protected override void Show(
                                    IDialogVisualizerService windowService,
                                    IVisualizerObjectProvider objectProvider)
       {
          var propertyGrid = new PropertyGrid();
          propertyGrid. Dock = DockStyle.Fill;
          propertyGrid.SelectedObject = objectProvider.GetObject();
    
          Form form = new Form { Text = propertyGrid.SelectedObject.ToString() };
          form.Controls.Add(propertyGrid);
    
          form.ShowDialog();
       }
    
       // Other stuff, see MSDN
    }
