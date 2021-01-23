    <Button Command="{Binding ChangePnumTextState}">
            <Button.Style>
                <Style TargetType="{x:Type Button}">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding DataContext.IsPNumLocked, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type UserControl}}}" Value="True">
                            <Setter Property="Content" Value="{StaticResource appbar_lock}"/>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding DataContext.IsPNumLocked, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type UserControl}}}" Value="False">
                            <Setter Property="Content" Value="{StaticResource appbar_unlock}"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
