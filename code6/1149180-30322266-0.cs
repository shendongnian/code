    <DataGrid  Name="DataGrid1" AutoGenerateColumns="False" ">
       <DataGrid.Columns>
          <DataGridTextColumn Header="Name" Binding="{Binding Path=Name}" Width="*"/>
       </DataGrid.Columns>
    </DataGrid>
    Public class Person {
     private String pm_Name = "";
    }
    Public String Name { 
      get { return pm_Name; } 
      set { pm_Name = value;} 
    }
    List<Person> Persons = new List<Persons>();
    Persons.Add(new Person() { Name = Sam });
    Persons.Add(new Person() { Name = Peter });
    DataGrid1.ItemsSource = Persons;
