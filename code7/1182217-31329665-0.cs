    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    public class Test : MonoBehaviour 
    {
	public Text myText;
	public string[] animalDescriptions = 
	{
		"Description 1",
		"Description 2",
		"Description 3",
		"Description 4",
		"Description 5",
	};
	void Start()
	{
		string myString = animalDescriptions [Random.Range (0, animalDescriptions.Length)];
		myText.text = myString;
	}
    }
