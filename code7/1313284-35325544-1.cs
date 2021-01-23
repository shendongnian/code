    using System;
	using System.Text;
	using System.Web.UI.WebControls;
	using System.Linq;
						
	public class Program
	{
		public static void Main()
		{
			var chBoxList= new CheckBoxList();
			chBoxList.Items.Add(new ListItem("Headache", "1"));
			chBoxList.Items.Add(new ListItem("Fever", "2"));
			chBoxList.Items.Add(new ListItem("Nause", "3"));
			
			chBoxList.Items[1].Selected = true;
			chBoxList.Items[2].Selected = true;
			
			string symptons = String.Join(", ", chBoxList.Items.Cast<ListItem>()
										  .Where(i => i.Selected)
										  .Select(i => i.Text));
			
			Console.WriteLine(symptons);
			
			
			using (MySqlConnection connection = new MySqlConnection(...))
			{
				connection.Open();
				
				using (MySqlCommand cmd = new MySqlCommand("select d.name , d.disease_id from Disease d inner join DiseaseSympton ds on ds.disease_id = d.disease_id inner join Sympton s on s.sympton_id = ds.sympton_id where s.name in ('@pSymptons');", connection))
				{
					cmd.Parameters.AddWithValue("@pSymptons", symptons);
					
					using (MySqlDataReader reader = cmd.ExecuteReader())
					{
						StringBuilder sb = new StringBuilder();
						
						while (reader.Read())
						{
							...
						}
					}
				}
			}
		}
	}
