                  private void Button_Click( object sender , RoutedEventArgs e )
                		{
                			Animal a = new Animal("Sheep" , 4);
                			XmlSerializer m = new XmlSerializer(typeof(Animal));
                			StringBuilder op = new StringBuilder();
                			var x = XmlWriter.Create(op);
                			m.Serialize(x , a);
                
                			string s = op.ToString();
                
                			var p = s.ToUpper();
                		}
                
                		public class Animal
                		{
                			public Animal( string name , int legcount )
                			{
                				this.name = name;
                				this.legcount = legcount;
                			}
                
                			public Animal()
                			{
                				this.name = "default";
                				this.legcount = 10000000;
                			}
                
                			public string name { get; set; }
                			public int legcount { get; set; }
                		}
