	public GameObject symbolCharacter;
	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData)
	{
		// Instantiate an object on Click
		symbolCharacter = Instantiate(Resources.Load ("Prefabs/Symbols/SymbolImage1")) as GameObject;
		symbolCharacter.transform.SetParent(GameObject.FindGameObjectWithTag("MessagePanel").transform);
	}
	#endregion
