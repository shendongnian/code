     public BaseConfig Config { get; set; }
     /****************************************/ 
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
    </Window.Resources>
    <Grid>
        <StackPanel>
             <ContentControl Content="{Binding Config}" />
             <Button VerticalAlignment="Bottom" Content="woosh" Click="Button_Click" />
        </StackPanel>
     </Grid>
