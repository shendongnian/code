    public IEnumerator loadProducts (int cat)
	{
		List <int> catNoTri = new List<int> ();
		catNoTri.Add (0);
		gm.totalPriceItem.Clear();
		isLoading = true;
		WWW www = new WWW ( urlProduct );
		yield return www;
		Debug.Log(www.text);
		string json = www.text.ToString ( );
		IndexPrductClass myJson = JsonReader.Deserialize<IndexPrductClass> ( json );
		foreach (productClass item in products) 
		{
			for (int i = 0; i < products.Length; i++) 
			{
				Debug.Log("product.productValue[i] = " + products[i].name);
			}
			if (firstLoad || gm.catId == 0) 
			{
				Debug.Log ("here1");
				nameProduct.Add (item.name);
				Debug.Log("item.name = " + item.name);
				idProduct.Add (item.id);
				prixItem.Add (item.pv_ttc);
				Debug.Log("item.pv_ttc = "  + item.pv_ttc);
				gm.totalPriceItem.Add (0);
				gm.qte = new int [gm.totalPriceItem.Count];
				descriptifProduct.Add (item.content);
				Debug.Log(" item.content = " +item.content);
			}
			else if (!firstLoad) 
			{
				Debug.Log ("here2");
				nameProduct.Add (item.name);
				idProduct.Add (item.id);
				prixItem.Add (item.pv_ttc);
				gm.totalPriceItem.Add (0);
				gm.qte = new int [gm.totalPriceItem.Count];
				descriptifProduct.Add (item.content);
			}
		}
		gm.canLoad = true;
	}
