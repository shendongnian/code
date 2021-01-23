    <ComboBox ItemsSource="{Binding CityList}"
             DisplayMemberPath="City"
             SelectedItem={Binding SelectedCity, Mode=TwoWay>
    </ComboBox>
    <ComboBox ItemsSource="{Binding CityList}"
             DisplayMemberPath="County"
             SelectedItem={Binding SelectedCounty, Mode=TwoWay>
    </ComboBox>
    <ComboBox ItemsSource="{Binding CityList}"
             DisplayMemberPath="State"
             SelectedItem={Binding SelectedState, Mode=TwoWay>
    </ComboBox>
