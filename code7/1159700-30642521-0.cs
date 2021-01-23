    using UnityEngine;
    using System.Collections;
    using System.IO;
    using UnityEngine.UI;
    using System.Collections.Generic;
    
    public class TextReadFromFile : MonoBehaviour {
    
    	GameObject player;
    	public TextAsset wordFile;                                // Text file (assigned from Editor)
    	private List<string> lineList = new List<string>();        // List to hold all the lines read from the text file
    	Text text;
    	Timer timer;
    	PlayerHealth playerHealth;
    
    	void Awake ()
    	{
    		player = GameObject.FindGameObjectWithTag ("Player");
    		playerHealth = player.GetComponent <PlayerHealth>();
    		text = GetComponent <Text>();
    	}
    	void Start()
    	{
    		ReadWordList();
    		Debug.Log("Random line from list: " + GetRandomLine());
    
    		StartCoroutine (Count(2.0f));
    
    		}
    	
    	public void ReadWordList()
    	{
    		// Check if file exists before reading
    		if (wordFile)
    		{
    			string line;
    			StringReader textStream = new StringReader(wordFile.text);
    			
    			while((line = textStream.ReadLine()) != null)
    			{
    				// Read each line from text file and add into list
    				lineList.Add(line);
    			}
    			
    			textStream.Close();
    		}
    	}
    	
    	public string GetRandomLine()
    	{
    		// Returns random line from list
    		return lineList[Random.Range(0, lineList.Count)];
    	}
    
    	IEnumerator Count(float WaitTime){
    		
    		while(playerHealth.currentHealth >= 0)
    		{
    			yield return new WaitForSeconds(WaitTime);
    			text.text = GetRandomLine();
    		}
    }
    
    
    }
