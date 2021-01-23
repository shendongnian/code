    <MultiDataTrigger>
        <MultiDataTrigger.Conditions>
            <Condition Binding="{Binding ElementName=buttonBibleReadingMain, Path=IsPressed, Mode=OneWay}" Value="false" />
            <Condition Binding="{Binding ElementName=buttonBibleReadingClass1, Path=IsPressed, Mode=OneWay}" Value="false" />
            <Condition Binding="{Binding ElementName=buttonBibleReadingClass2, Path=IsPressed, Mode=OneWay}" Value="false" />
        </MultiDataTrigger.Conditions>
        <Setter Property="IsChecked" Value="false"/>
    </MultiDataTrigger>
