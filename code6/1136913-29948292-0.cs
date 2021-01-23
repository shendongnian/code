    <DataGridTextColumn  Binding="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Window}}, 
                    Path=concatenarMoneda,Mode=OneWay}" Header="Costo" Width="*"/>  
    public string concatenarMoneda
        {
            get
            {
                return viewModel.Registro.Costo.ToString() + " " + viewModel.Registro.SOSMoneda.Descripcion;
            }
        }
