    <ContentControl
        Content="{Binding}"
        >
        <ContentControl.Style>
            <Style TargetType="ContentControl">
                <!-- Default has to go in a setter in the Style, not an 
                     attribute on the ContentControl tag -->
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
