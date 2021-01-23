		// Custom comparer for the SelectListItem class
		class SelectListItemComparer : IEqualityComparer<SelectListItem>
		{
			// Products are equal if their names and product numbers are equal.
			public bool Equals(SelectListItem x, SelectListItem y)
			{
				//Check whether the compared objects reference the same data.
				if (Object.ReferenceEquals(x, y)) return true;
				//Check whether any of the compared objects is null.
				if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
					return false;
				//Check whether the products' properties are equal.
				return x.Text.Equals(y.Text) && x.Value.Equals(y.Value);
			}
			// If Equals() returns true for a pair of objects 
			// then GetHashCode() must return the same value for these objects.
			public int GetHashCode(SelectListItem item)
			{
				//Check whether the object is null
				if (Object.ReferenceEquals(item, null)) return 0;
				//Get hash code for the Name field if it is not null.
				int hashText = item.Text == null ? 0 : item.Text.GetHashCode();
				//Get hash code for the Code field.
				int hashValue = item.Value.GetHashCode();
				//Calculate the hash code for the product.
				return hashText ^ hashValue;
			}
		}
