	 <Window.Resources>
		<DataTemplate DataType="{x:Type o:ConfigA}">
			<!--
			  You can add here any control you wish applicable to ConfigA.
			  Say, a textbox can do.  
			 -->
			<TextBlock Text="{Binding A}"/>
		</DataTemplate>
		<DataTemplate DataType="{x:Type o:ConfigB}">
			<TextBlock Text="{Binding B}"/>
		</DataTemplate>
		<DataTemplate DataType="{x:Type o:ConfigType10000000000}">
			<superComplicatedControl:UniqueControl ProprietaryProperty="{Binding CustomProperty}"/>
		</DataTemplate>
		<!--  Rachel's point  -->
		<DataTemplate DataType="{x:Type o:Config4}">
			<StackPanel>
			   <ContentControl Content="{Binding ConfigA}"/>
			   <ContentControl Content="{Binding ConfigB}"/>
			</StackPanel>
		</DataTemplate>
	</Window.Resources>
	<Grid>
		<StackPanel>
			 <ContentControl Content="{Binding Config}" />
			 <Button VerticalAlignment="Bottom" Content="woosh" Click="Button_Click" />
		</StackPanel>
	 </Grid>
<!---->
	private void Button_Click(object sender, RoutedEventArgs e)
	{
		// Config = new ConfigB() { B = "bbb" };
		Config = new Config4() { ConfigA = (ConfigA) Config, ConfigB = new ConfigB { B = "bbb" } };
		DataContext = null;
		DataContext = this;
	}
	
	//…
	
	// Rachel's point
	public class Config4 : BaseConfig
	{
		public string A4 { get; set; }
		public ConfigA ConfigA { get; set; }
		public ConfigB ConfigB { get; set; } 
	}
