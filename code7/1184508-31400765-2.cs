    <Window.Resources>
        <Style x:Key="Multi" TargetType="{x:Type Button}" >
            <Style.Triggers>
                <MultiTrigger>
                    <MultiTrigger.Conditions>
                        <Condition Property="IsDefault" Value="True"></Condition>
                        <Condition Property="IsMouseOver" Value="True"></Condition>
                    </MultiTrigger.Conditions>
                    <MultiTrigger.Setters>
                        <Setter Property="Background" Value="White" ></Setter>
                    </MultiTrigger.Setters>
                </MultiTrigger>
            </Style.Triggers>
        </Style>
     </Window.Resources>
     <Grid>
        <Button Style="{StaticResource Multi}"></Button>
     </Grid>
