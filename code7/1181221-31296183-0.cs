    <Setter Property="Template">
       <Setter.Value>
          <ControlTemplate TargetType="ComboBox">
             <Grid>
                <Border x:Name="ContentPresenterBorder">
                   <Grid>
                      <ToggleButton x:Name="DropDownToggle"/>
                      <ContentPresenter x:Name="ContentPresenter" />
                         <TextBlock Text=" " />
                      </ContentPresenter>
                   </Grid>
                </Border>
             </Grid>
          </ControlTemplate>
       </Setter.Value>
    </Setter>
