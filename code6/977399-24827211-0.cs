    <UserControl ...>
        <UserControl.Resources>
            <valueConverters:VisibilityConverter x:Key="VisibilityConverter"/>
        </UserControl.Resources>
        <UserControl.Visibility>
            <Binding 
                RelativeSource="{RelativeSource Self}" 
                Path="ShowMyself" 
                Converter="{StaticResource VisibilityConverter}"/>
        </UserControl.Visibility>
        <!-- .... -->
    </UserControl>
