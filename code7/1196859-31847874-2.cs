		<Window x:Class="WpfApplication1.MainWindow"
				xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
				xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
				Title="MainWindow" Height="350" Width="525" Loaded="Window1_Load">
			<Window.Resources>
				<SolidColorBrush x:Key="clBl" Color="Blue" />
				<SolidColorBrush x:Key="clred" Color="Red" />
				<SolidColorBrush x:Key="clgreen" Color="Green" />
			</Window.Resources>
			<Grid>
				<DataGrid Name="grd" AutoGenerateColumns="False" ItemsSource="{Binding}">
					<DataGrid.Columns>
						<DataGridTextColumn Header="Name" Binding="{Binding Name}" >
							<DataGridTextColumn.CellStyle>
								<Style TargetType="DataGridCell">
									<Setter Property="Background" 
										Value="{StaticResource clred}" />
								</Style>
							</DataGridTextColumn.CellStyle>
						</DataGridTextColumn>
						<DataGridTemplateColumn Header="Weight">
							<DataGridTemplateColumn.CellTemplate>
								<DataTemplate>
									<TextBlock Text="{Binding Path=Weight}" />
								</DataTemplate>
							   
							</DataGridTemplateColumn.CellTemplate>
						   
							<DataGridTemplateColumn.CellEditingTemplate>
								<DataTemplate>
									<TextBox Text="{Binding Path=Weight}" />
								</DataTemplate>
							</DataGridTemplateColumn.CellEditingTemplate>
							<DataGridTemplateColumn.CellStyle>
								<Style TargetType="DataGridCell">
									<Setter Property="Background" 
										Value="{StaticResource clBl}" />
								</Style>
							</DataGridTemplateColumn.CellStyle>
						</DataGridTemplateColumn>
						<DataGridTextColumn Header="Created At" Binding="{Binding CreatedAt}" >
							<DataGridTextColumn.CellStyle>
								<Style TargetType="DataGridCell">
									<Setter Property="Background" 
										Value="{StaticResource clgreen}" />
								</Style>
							</DataGridTextColumn.CellStyle>
							</DataGridTextColumn>
					</DataGrid.Columns>
				</DataGrid>
			</Grid>
		</Window>
