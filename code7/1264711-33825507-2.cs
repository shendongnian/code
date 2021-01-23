	public void Print(string prefix = string.Empty)
	{
		Console.WriteLine(prefix + this.Description);
        if (this.Childs != null)
        {
		    foreach (var item in this.Childs)
		    {
			    item.Print(prefix + "-");
		    }
        }
	}
