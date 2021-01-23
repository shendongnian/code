	dynamic row = JsonConvert.DeserializeObject(obj[i].ToString());
	Console.WriteLine(row.title.ToString() + " (€" + row.price.ToString() + ") ");
	Console.WriteLine(row.price.ToString());
	Console.WriteLine(row.urlimage.ToString());
	Console.WriteLine(row.votes.ToString());
	Console.WriteLine(row.category.ToString());
	Console.WriteLine(row.user.username.ToString());
	Console.WriteLine();
	Console.WriteLine("-----------------------------\n");
