    <ContentControl
        Content="{Binding}"
        >
        <ContentControl.Style>
            <Style TargetType="ContentControl">
                <Setter 
                    Property="ContentTemplate" 
                    Value="{StaticResource EditUserTemplate}" 
                    />
                <Style.Triggers>
                    <DataTrigger Binding="{Binding UserID}" Value="{x:Null}">
                        <Setter 
                            Property="ContentTemplate" 
                            Value="{StaticResource CreateUserTemplate}" 
                            />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ContentControl.Style>
    </ContentControl>
