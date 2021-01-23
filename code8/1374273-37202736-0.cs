	public class Person {
		public String Name {get; set;}
		public int Age {get; set;}
	}
	public class PersonVM {
		public PersonVM(Person model) {
			_model = model;
		}
		private readonly Person _model;
		internal Person Model {get {return _model;}}
		public String Name {
			get { return _model.Name; }
			set { _model.Name = value; }
		}
		public int Age {
			get {return _model.Age;}
			set { _model.Name = value; }
		}
	}
	//PersonV.xaml
	<StackPanel>
		<TextBlock Text="{Binding Name}"/>
		<TextBlock Text="{Binding Age}"/>
	</StackPanel>
	public class People : ObservableCollection<Person> {
	}
	public class PeopleVM : ObservableCollection<PersonVM> {
		public PeopleVM(People model) {
			_model = model;
			foreach(Person p in _model) {
				Add(new PersonVM(p));
			}
			_model.CollectionChanged += CollectionChangedHandler;
		}
		private void CollectionChangedHandler(Object sender, NotifyCollectionChangedEventArgs args) {
			switch (notifyCollectionChangedEventArgs.Action) {
	            case NotifyCollectionChangedAction.Add:
	            	foreach(People p in args.NewItems) {
	            		if(!this.Any(pvm => pvm.Model == p)) {
	            			this.Add(new PersonVM(p));
	            		}
	            	}
	            	
	                break;
	            case NotifyCollectionChangedAction.Remove:
	            	foreach(People p in args.OldItems) {
	            		PersonVM pvm = this.FirstOrDefault(pe => pe.Model == p);
	            		if(pvm != null) this.Remove(pvm);
	            	}
	                break;
	             case NotifyCollectionChangedAction.Reset:
	         		Clear();
	                break;
	            default:
	                break;
	            }
		}
		private readonly People _model;
	}
	//PeopleV.xaml
	<ItemsControl ItemsSource={Binding}>
		<ItemsControl.ItemTemplate>
			<DataTemplate DataType="{x:Type PersonVM}">
				<PersonV/>
			</DataTemplate>
		</ItemsControl.ItemTemplate>
	</ItemsControl>
	public class AppVM {
		public AppVM() {
			People p = ServiceLayer.LoadPeople(); //load people
			People = new PeopleVM(p);
		}
		public PeopleVM People {get; set;};
	}
	//MainWindow.xaml
	<Window ...
		>
		<Window.DataContext>
			<local:AppVM/>
		</Window.DataContext>
		<PeopleV/>
	</Window>
