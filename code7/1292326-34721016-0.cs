    		TreeIter iter;
			yourNodeView.Model.GetIterFirst (out iter);
			for (int i = 0; i < yourNodeView.Model.IterNChildren(); i++)
			{
				string result = ((TypeOfListItem)sequencerNodeView.Model.GetValue (iter, 0)).ToString();
				//Here you would add the TypeOfListItem instance to a new ArrayList, and then after the loop swap out the old ArrayList for the new one. 
				Console.WriteLine("print the item "+result);
				yourNodeView.Model.IterNext(ref iter);
			}
