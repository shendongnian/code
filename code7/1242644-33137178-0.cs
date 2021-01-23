    <Grid Background="Black">
          <Grid.Resources>
             <Style TargetType="RowDefinition">
                 <Setter Property="Height" Value="Auto"/>
                 <Style.Triggers>
                     <DataTrigger Binding="{Binding IsExpanded, RelativeSource={RelativeSource Self}}" 
                                  Value="True">
                         <Setter Property="Height" Value="*"/>
                     </DataTrigger>
                 </Style.Triggers>
             </Style>
          </Grid.Resources>
          <Grid.RowDefinitions>
             <RowDefinition Tag="{Binding ElementName=articlesExpander}"/>
             <RowDefinition Tag="{Binding ElementName=turneroExpander}"/>
          </Grid.RowDefinitions>
          <Expander Name="articlesExpander" Template="{StaticResource ExpanderHeaderImage}">
                <Grid Name="articlesGridExpander" ShowGridLines="True" Background="#FFEC0000">
                  <TextBlock>Hello</TextBlock>
                </Grid>
          </Expander>
          <Expander Name="turneroExpander" Template="{StaticResource ExpanderHeaderImage}" Grid.Row="1">
                <Grid Name="turneroGridExpander" ShowGridLines="True" Height="{Binding ElementName=DummyExpanderHeight, Path=Height}" Background="#FF0AE400">
                   <TextBlock>Bye</TextBlock>
                </Grid>
          </Expander>
     </Grid>
