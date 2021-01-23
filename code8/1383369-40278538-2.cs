        <Entry Text="{Binding DateOfBirth, Mode=TwoWay}" />
        <Image Source="button.png" WidthRequest="39">
            <Image.GestureRecognizers>
                <TapGestureRecognizer Command="{Binding OnSelectDOBCommand}" CommandParameter="{Binding ., Source={Reference DOBPicker}}" />
            </Image.GestureRecognizers>
        </Image>
        <DatePicker x:Name="DOBPicker"
                    Date="{Binding SelectedDOB}"
                    IsEnabled="True"
                    IsVisible="False">
            <DatePicker.Behaviors>
                <behaviors:DatePickerSelectedBehavior Command="{Binding DateSelectedCommand}" EventName="DateSelected" />
            </DatePicker.Behaviors>
        </DatePicker>
