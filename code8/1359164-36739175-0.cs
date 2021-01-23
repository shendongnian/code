     public class Country
            {
                public Guid Guid { get; set; } = Guid.NewGuid();
                public string Name { get; set; }
                public bool Selected{get;set;}
                public Country(string name)
                {
                    Name = name;
                }
            }
        
               <DataTemplate>
                        <CheckBox Content="{Binding Name}" Checked="{Binding Selected}"/>
               </DataTemplate>
