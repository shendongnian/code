    <TextBox Height="23" Name="textBox1" Margin="25">
         <TextBox.Style>
              <Style>
                  <Style.Triggers>
                      <Trigger Property="Validation.HasError" Value="True">
                           <Setter Property="ToolTip" Value="{Binding RelativeSource={RelativeSource Self},Path=(Validation.Errors)[0].ErrorContent}"/>
                           <Setter Property="Background" Value="Red"/>                            
                           <Setter Property="TextBox.BorderThickness" Value="2"/>
                      </Trigger>
                  </Style.Triggers>
              </Style>
         </TextBox.Style>
         <Validation.ErrorTemplate>
            <ControlTemplate>
                <DockPanel>
                   <TextBlock Foreground="Red" DockPanel.Dock="Right">!</TextBlock>
                   <AdornedElementPlaceholder x:Name="ErrorAdorner"
        ></AdornedElementPlaceholder>
                </DockPanel>
            </ControlTemplate>
         </Validation.ErrorTemplate>
                
         <TextBox.Text>
            <Binding Path="Name" Mode="TwoWay" UpdateSourceTrigger="PropertyChanged">
               <Binding.ValidationRules>
                  <local:NameValidator></local:NameValidator>
               </Binding.ValidationRules>
            </Binding>
         </TextBox.Text>
    </TextBox>
