    <TextBox.Template>
       <ControlTemplate>
          <Grid>
             <Grid.ColumnDefinitions>
                <ColumnDefinition Width="107*"/>
                <ColumnDefinition Width="23*"/>
             </Grid.ColumnDefinitions>
             <TextBox Grid.ColumnSpan="1" />
             <Border Name="border" BorderBrush="DarkGreen" BorderThickness="1" Grid.ColumnSpan="1" Visibility="Hidden">
             </Border>
             <Image Name="checkmark" Grid.Column="1" Source="Images/check_48.ico" Grid.ColumnSpan="2" Visibility="Hidden"  />
          </Grid>
          <ControlTemplate.Triggers>
             <MultiTrigger>
                <MultiTrigger.Conditions>
                   <Condition Property="IsMouseOver" Value="True" />
                </MultiTrigger.Conditions>
                <Setter Property="Visibility" TargetName="border" Value="Visible" />
                <Setter Property="Visibility" TargetName="checkmark" Value="Visible" />
             </MultiTrigger>
          </ControlTemplate.Triggers>
       </ControlTemplate>
    </TextBox.Template>
