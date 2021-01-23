    <TextBox Grid.Row="0" Margin="4" MinWidth="150" Name="SearchBox" VerticalAlignment="Center">
        <i:Interaction.Triggers>
            <ei:PropertyChangedTrigger Binding="{Binding IsOpen, RelativeSource={RelativeSource AncestorType=ContextMenu, Mode=FindAncestor}}">
                <ei:CallMethodAction MethodName="FocusSearchBox" TargetObject="{Binding DataContext, ElementName=SearchBox}"/>
                <ei:ChangePropertyAction PropertyName="Background" Value="Purple"/>
            </ei:PropertyChangedTrigger>
        </i:Interaction.Triggers>
    </TextBox>
 
    public void FocusSearchBox()
            {
                TextBox t = (TextBox) CtxMenu.ContextMenu.Template.FindName("SearchBox", CtxMenu.ContextMenu);
                t.Focus();
            }
