	public SomeViewModel()
	{
		_deleteUser = new DelegateCommand(user =>
			Users.Remove((Person)user)
		);
	}
	private readonly ObservableCollection<Person> _Users;
	public ObservableCollection<Person> Users { get { return _Users; } }
	private readonly DelegateCommand _deleteUser;
	public DelegateCommand DeleteUser { get { return _deleteUser; } }
<!---->
	<ItemsControl ItemsSource="{Binding Users}">
		<ItemsControl.ItemTemplate>
			<DataTemplate>
				<StackPanel Orientation="Horizontal">
					<!-- Some content here -->
					<Button Command="{Binding RelativeSource={RelativeSource AncestorType=ItemsControl},
											Path=DataContext.DeleteUser}"
							CommandParameter="{Binding}">Remove</Button>
				</StackPanel>
			</DataTemplate>
		</ItemsControl.ItemTemplate>
	</ItemsControl>
